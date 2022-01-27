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
using Azure.Search.Documents;
using Azure;

using NuSearch.Models.Search.Operator;

namespace NuSearch.Services.Search
{
    public static class NutrikoSearchService
    {
        public static void AddNutrikoSearchService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AzureSearch>(configuration.GetSection("Services:AzureSearch"));

            services.AddSingleton( (container) => {
                var logger = container.GetRequiredService<ILogger<NutrikoSearch>>();
                var conf = container.GetRequiredService<IOptions<AzureSearch>>();

                return InitializeNutrikoSearch(conf, logger).GetAwaiter().GetResult();
            });

        }

        public static async Task<SearchClient> InitializeNutrikoSearch(IOptions<AzureSearch> options, ILogger<NutrikoSearch> logger)
        {
            SearchClient searchClient = new SearchClient( new Uri(options.Value.Endpoint), options.Value.Options.Index, new AzureKeyCredential(options.Value.Apikey));

            return searchClient;
        }
    }

    public class NutrikoSearch
    {

    }
    
}

/**
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
            
            RecipesReader recipesCosmosClient = new RecipesReader(logger, cosmosConfig, cosmosClient);

            CosmosDatabase cosmosDatabase = cosmosClient.GetDatabase(cosmosConfig.databaseId);
            cosmosDatabase.GetContainer(cosmosConfig.containerId);

            return recipesCosmosClient;
        }
    }
    **/