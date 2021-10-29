using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Azure.Cosmos;
using Azure.Core;
using Azure;

using NuRecipesAgent.Models.Recipes;

namespace NuRecipesAgent.Services.CosmosServiceClient
{
    public static class RecipesCosmosClientExtension
    {
        public static void AddRecipesCosmosClientExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RecipesCosmosDbConfig>(
                configuration.GetSection("Resources:CosmosDb")
            );
            
            services.AddSingleton<IRecipesCosmosClient>( (container) => {
                var logger = container.GetRequiredService<ILogger<RecipesCosmosClient>>();
                var conf = container.GetRequiredService<IOptions<RecipesCosmosDbConfig>>();

                return InitializeRecipesCosmosInstance(conf, logger).GetAwaiter().GetResult();

            });
            
        }

        public static async Task<RecipesCosmosClient> InitializeRecipesCosmosInstance(IOptions<RecipesCosmosDbConfig> options, ILogger<RecipesCosmosClient> logger)
        {
            var cosmosConfig = options.Value;

            CosmosClientOptions cosmosClientOptions = new CosmosClientOptions {
                MaxRetryAttemptsOnRateLimitedRequests = 9,
                MaxRetryWaitTimeOnRateLimitedRequests = TimeSpan.FromSeconds(60)
            };

            CosmosClient cosmosClient = new CosmosClient(
                cosmosConfig.endPointUrl, cosmosConfig.authorizationKey, cosmosClientOptions
            );

            RecipesCosmosClient recipesCosmosClient = new RecipesCosmosClient(logger, cosmosConfig, cosmosClient);

            DatabaseResponse databaseResponse = await cosmosClient.CreateDatabaseIfNotExistsAsync(cosmosConfig.databaseId);
            ContainerProperties containerProperties = new ContainerProperties() {
                Id = cosmosConfig.containerId,
                PartitionKeyPath = $"/{cosmosConfig.partitionKey}"
            };

            await databaseResponse.Database.CreateContainerIfNotExistsAsync(containerProperties);

            return recipesCosmosClient;
        }
    }

    public class RecipesCosmosClient : IRecipesCosmosClient
    {
        private ILogger<RecipesCosmosClient> _logger;
        private RecipesCosmosDbConfig _recipesCosmosDbConfig;
        private CosmosContainer _cosmosContainer;

        public RecipesCosmosClient(ILogger<RecipesCosmosClient> logger, RecipesCosmosDbConfig cosmosDbConfig, CosmosClient cosmosClient)
        {
            _recipesCosmosDbConfig = cosmosDbConfig;
            _cosmosContainer = cosmosClient.GetContainer(_recipesCosmosDbConfig.databaseId, _recipesCosmosDbConfig.containerId);
            _logger = logger;
        }

        public void Echo(string s)
        {
            Console.WriteLine($"echo => {s}");
        }

        public async Task<ItemResponse<Recipe>> AddRecipeAsync(Recipe recipe)
        {
            _logger.LogInformation("Creating item: " + recipe.id);
            return await _cosmosContainer.CreateItemAsync<Recipe>(recipe, new PartitionKey(recipe.type));

        }

        public async Task<ItemResponse<Recipe>> UpsertRecipeAsync(Recipe recipe)
        {
            _logger.LogInformation("Upserting item: " + recipe.id);
            return await _cosmosContainer.UpsertItemAsync<Recipe>(recipe, new PartitionKey(recipe.type));

        }

        public async Task<ItemResponse<Recipe>> DeleteRecipeAsync(Recipe recipe)
        {
            _logger.LogInformation("Deleting item: " + recipe.id);
            return await _cosmosContainer.DeleteItemAsync<Recipe>(recipe.id, new PartitionKey(recipe.type));
        }

        //public async Task<ItemResponse<Recipe>> GetRecipeListAsync(Recipe recipe) { }
    }

}