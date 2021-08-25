using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Azure.Cosmos;

using FdcAgent.Services.FoodBusService;
using FdcAgent.Models.FdcShemas;

namespace FdcAgent.Services.CosmosClientService
{
    public static class FdcAgentCosmosClientExtension
    {
        public static void AddFdcAgentCosmosClientService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FdcAgentCosmosDbConfig>(
                configuration.GetSection("DataStores:CosmosDb")
            );

            services.AddScoped<IFdcAgentCosmosClient, FdcAgentCosmosClient>();
        }
    }

    public class FdcAgentCosmosClient : IFdcAgentCosmosClient
    {
        private readonly FdcAgentCosmosDbConfig _cosmosDbConfig;
        private static CosmosClient _cosmosClient = null;
        private static readonly CosmosClientOptions _cosmosClientOptions;
        private CosmosDatabase _cosmosDatabase;
        private CosmosContainer _cosmosContainer;
        private IFdcAgentBusConsumer _messageConsumer;
        private IList<SRLegacyFoodItem> _itemsList;

        public FdcAgentCosmosClient(IOptions<FdcAgentCosmosDbConfig> options, IFdcAgentBusConsumer messageConsumer)
        {
            _messageConsumer = messageConsumer;
            _cosmosDbConfig = options.Value;
            _cosmosClient = new CosmosClient(_cosmosDbConfig.endPointUrl, _cosmosDbConfig.authorizationKey);
        }

        private async Task CreateDatabase()
        {
            try
            {
                _cosmosDatabase = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_cosmosDbConfig.databaseId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task CreateContainer()
        {
            ContainerProperties containerProperties = new ContainerProperties() {
                Id = _cosmosDbConfig.containerId,
                PartitionKeyPath = $"/{_cosmosDbConfig.partitionKey}"
            };

            try
            {
                _cosmosContainer = await _cosmosDatabase.CreateContainerIfNotExistsAsync(containerProperties);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<dynamic> StartImport(IList<SRLegacyFoodItem> list)
        {

            foreach (var food in list)
            {
                Console.WriteLine($"func StartImport: {food.fdcId} -- {food.description}");
            }
            
            return "import";
        }

        public void printConfig()
        {
            Console.WriteLine(JsonSerializer.Serialize(_cosmosDbConfig));
        }
        
    }
}