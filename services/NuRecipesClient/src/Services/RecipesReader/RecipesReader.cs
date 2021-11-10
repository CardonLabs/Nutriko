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

using NuRecipesClient.Models.Recipes;

namespace NuRecipesClient.Services.RecipesServiceReader
{
    public static class RecipesCosmosReaderService
    {
        public static void AddRecipesCosmosReaderService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RecipesReaderConfig>(
                configuration.GetSection("Resources:CosmosDb")
            );
            
            services.AddSingleton<IRecipesReader>( (container) => {
                var logger = container.GetRequiredService<ILogger<RecipesReader>>();
                var conf = container.GetRequiredService<IOptions<RecipesReaderConfig>>();

                return InitializeRecipesCosmosInstance(conf, logger).GetAwaiter().GetResult();

            });
            
        }

        public static async Task<RecipesReader> InitializeRecipesCosmosInstance(IOptions<RecipesReaderConfig> options, ILogger<RecipesReader> logger)
        {
            var cosmosConfig = options.Value;

            CosmosClientOptions cosmosClientOptions = new CosmosClientOptions {
                MaxRetryAttemptsOnRateLimitedRequests = 9,
                MaxRetryWaitTimeOnRateLimitedRequests = TimeSpan.FromSeconds(60)
            };

            CosmosClient cosmosClient = new CosmosClient(
                cosmosConfig.endPointUrl, cosmosConfig.authorizationKey, cosmosClientOptions
            );

            /**
            *
            *   Need some try catch logic here
            *
            **/

            RecipesReader recipesCosmosClient = new RecipesReader(logger, cosmosConfig, cosmosClient);

            DatabaseResponse databaseResponse = await cosmosClient.GetDatabase(cosmosConfig.databaseId);

            await databaseResponse.Database.GetContainer(cosmosConfig.containerId);

            return recipesCosmosClient;
        }
    }

    public class RecipesReader : IRecipesReader
    {
        private ILogger<RecipesReader> _logger;
        private RecipesReaderConfig _recipesCosmosDbConfig;
        private CosmosContainer _cosmosContainer;

        public RecipesReader(ILogger<RecipesReader> logger, RecipesReaderConfig cosmosDbConfig, CosmosClient cosmosClient)
        {
            _recipesCosmosDbConfig = cosmosDbConfig;
            _cosmosContainer = cosmosClient.GetContainer(_recipesCosmosDbConfig.databaseId, _recipesCosmosDbConfig.containerId);
            _logger = logger;

        }

        public async Task<ItemResponse<Recipe>> GetRecipeAsync(string id)
        {
            _logger.LogInformation("Reading items {0}", id);

            using(ResponseMessage responseMessage = await _cosmosContainer.ReadItemStreamAsync(partitionKey: new PartitionKey("recipe"), id: id))
            {
                if(responseMessage.IsSuccessStatusCode)
                {
                    Recipe streamRecipe = FromStream<Recipe>(responseMessage.Content);
                    Console.WriteLine("Item is: {0} ", streamRecipe.details.name);
                    Console.WriteLine("Cost is: {0} ", streamRecipe.RequestCharge);
                }
            }

        }
        
    }

}