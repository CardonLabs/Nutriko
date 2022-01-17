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

            CosmosDatabase cosmosDatabase = cosmosClient.GetDatabase(cosmosConfig.databaseId);
            cosmosDatabase.GetContainer(cosmosConfig.containerId);

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

        public async Task<RecipesClientResponse> GetRecipeAsync(string id)
        {
            RecipesClientResponse recipesClientResponse = new RecipesClientResponse();
            
            _logger.LogInformation("Reading items {0}", id);

            try
            {
                ItemResponse<Recipe> itemResponse = await _cosmosContainer.ReadItemAsync<Recipe>(id, new PartitionKey("recipe"));
                recipesClientResponse.recipe = itemResponse.Value;
                recipesClientResponse.status = HttpStatusCode.OK;
                recipesClientResponse.message = "Item found " + itemResponse.Value.id;

            }
            catch (CosmosException exception)
            {
                recipesClientResponse.status = (HttpStatusCode)exception.Status;
                recipesClientResponse.message = exception.Message;
                _logger.LogInformation("Status: {0} - Message: {1}", exception.Status, exception.Message);
            }

            return recipesClientResponse;

        }

        public async Task<PaginatedRecipesClientResponse<Recipe>> GetPaginatedRecipesAsync(string continuationToken)
        {
            var conToken = continuationToken != null ? continuationToken : null;

            try
            {
                var query = new QueryDefinition("SELECT * FROM c");
            
                var queryResultSetIterator = _cosmosContainer.GetItemQueryIterator<Recipe>(
                    query,
                    conToken,
                    requestOptions: new QueryRequestOptions() { 
                        PartitionKey = new PartitionKey("recipe"),
                        MaxItemCount = _recipesCosmosDbConfig.pageSize,
                    }
                ).AsPages();
                
                var result = await queryResultSetIterator.FirstOrDefaultAsync();

                var sourceContinuationToken = result.ContinuationToken != null ? 
                        JsonSerializer.Deserialize<ContinuationToken>(result.ContinuationToken).SourceContinuationToken : null;

                var response = new PaginatedRecipesClientResponse<Recipe>() {
                    message = $"Found {result.Values.Count} items",
                    status = HttpStatusCode.OK,
                    continuationToken = sourceContinuationToken,
                    recipe = result.Values.ToList()
                };
                
                return response;
            }
            catch (CosmosException e)
            {
                _logger.LogInformation("Status: {0} - Message: {1}", e.Status, e.Message);

                var response = new PaginatedRecipesClientResponse<Recipe>() {
                    message = e.Message,
                    status = (HttpStatusCode)e.Status
                };

                return response;
            }
        }
        
    }

}