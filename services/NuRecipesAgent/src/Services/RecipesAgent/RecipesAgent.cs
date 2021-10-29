using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Azure.Storage.Blobs;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Processor;
using System.Reactive;
using System.Reactive.Subjects;
using System.Reactive.Linq;

using NuRecipesAgent.Models.Options;
using NuRecipesAgent.Models.Recipes;
using NuRecipesAgent.Services.CosmosServiceClient;

namespace NuRecipesAgent.Services.Recipes
{
    public static class RecipesAgentExtension
    {
        public static void AddRecipesAgentService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Resources>(
                configuration.GetSection("Resources")
            );

            services.AddSingleton<IRecipesAgent, RecipesAgent>();
        }
    }
    public class RecipesAgent : IRecipesAgent
    {
        private ILogger<RecipesAgent> _logger;
        private Resources _resources;
        private BlobContainerClient _containerClient;
        private EventProcessorClient _processorClient;
        private IRecipesBusService _recipesBusService;
        private IDisposable _recipesSubscription;

        private readonly IRecipesCosmosClient _recipesCosmosClient;

        public RecipesAgent( ILogger<RecipesAgent> logger, IOptions<Resources> options, 
            IRecipesCosmosClient recipesCosmosClient, IRecipesBusService recipesBusService)
        {
            _logger = logger;
            _resources = options.Value;
            _recipesCosmosClient = recipesCosmosClient;
            _recipesBusService = recipesBusService;

            _containerClient = new BlobContainerClient(
                _resources.blobStorage.EndPoint, _resources.blobStorage.Container
            );

            _processorClient = new EventProcessorClient(
                _containerClient, _resources.eventHub.ConsumerGroup, 
                _resources.eventHub.EndPoint, _resources.eventHub.HubName
            );
        }

        public async Task StartListening(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    //using var cancellationSource = new CancellationTokenSource();

                    _processorClient.ProcessEventAsync += ProcessEventHandler;
                    _processorClient.ProcessErrorAsync += ProcessErrorHandler;

                    try
                    {
                        await _processorClient.StartProcessingAsync();
                        await Task.Delay(Timeout.Infinite, stoppingToken);
                        
                    }
                    catch (TaskCanceledException)
                    {
                        _logger.LogError("something went wrong");
                        throw;
                    }
                    finally
                    {
                        _recipesBusService.AllItemsProcessed();
                        await _processorClient.StopProcessingAsync();
                    }
                }
                catch
                {

                }
                finally
                {
                    _processorClient.ProcessEventAsync -= ProcessEventHandler;
                    _processorClient.ProcessErrorAsync -= ProcessErrorHandler;
                }
            }
        }

        private async Task ProcessEventHandler(ProcessEventArgs eventArgs)
        {
            var recipeItem = JsonSerializer.Deserialize<Recipe>(Encoding.UTF8.GetString(eventArgs.Data.Body.ToArray()));
            var recipeOperation = eventArgs.Data.Properties["operation"].ToString();
            var recipeEventType = eventArgs.Data.Properties["type"].ToString();

            RecipesBusMessage message = new RecipesBusMessage {
                type = recipeEventType,
                operation = recipeOperation,
                recipe = recipeItem
            };

            _recipesSubscription = _recipesBusService.recipesObservable
                .Where( e => string.Equals( e.type, "nutriko/type/recipe"))
                .Subscribe<RecipesBusMessage>( async e => {

                    _logger.LogInformation("Received recipe event: " + e.operation + " -- " + e.recipe.id);

                    try
                    {
                        /**
                            This needs a lot of work - this is too ewwww
                        **/
                        if(e.operation == "nutriko/operation/post")
                        {
                            var operation = await _recipesCosmosClient.AddRecipeAsync(e.recipe);
                            _logger.LogInformation("Recipe committed to store: " + e.recipe.id ?? "no insert" + " with Etag: " + operation.ETag.Value );
                        }

                        if(e.operation == "nutriko/operation/upsert")
                        {
                            var operation = await _recipesCosmosClient.UpsertRecipeAsync(e.recipe);
                            _logger.LogInformation("Recipe upsert to store: " + e.recipe.id ?? "no upsert" + " with Etag: " + operation.ETag.Value);
                        }

                        if(e.operation == "nutriko/operation/delete")
                        {
                            var operation = await _recipesCosmosClient.DeleteRecipeAsync(e.recipe);
                            _logger.LogInformation("Recipe deleted: " + e.recipe.id ?? "no delete" + " with Etag: " + operation.ETag.Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogInformation("Recipe error: " + ex.Message);
                        throw;
                    }
                }
            );

            _recipesBusService.PublishMessage(message);
            
            _logger.LogInformation("Check-pointing event... ");
            await eventArgs.UpdateCheckpointAsync(eventArgs.CancellationToken);
            
            _recipesSubscription.Dispose();
            
        }

        private Task ProcessErrorHandler(ProcessErrorEventArgs eventArgs)
        {
            // Write details about the error to the console window
            Console.WriteLine($"\tPartition '{ eventArgs.PartitionId}': an unhandled exception was encountered. This was not expected to happen.");
            Console.WriteLine(eventArgs.Exception.Message);
            return Task.CompletedTask;
        }
    }

}