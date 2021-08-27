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
using FdcAgent.Models.FdcShemas.Nutriko;

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
        private CosmosDatabase _cosmosDatabase = null;
        private CosmosContainer _cosmosContainer = null;
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

        public async Task<dynamic> StartImport(IList<NuFoodItem> list)
        {
            if (_cosmosDatabase == null)
                await CreateDatabase();

            if (_cosmosContainer == null)
                await CreateContainer();
            
            try
            {
                var itemsBucket = new List<KeyValuePair<PartitionKey, Stream>>();
                foreach (var item in list)
                {
                    var stream = new MemoryStream();
                    await JsonSerializer.SerializeAsync<NuFoodItem>(stream, item);

                    itemsBucket.Add(new KeyValuePair<PartitionKey, Stream>(new PartitionKey(item.dataType), stream));
                }

                var parallelJobs = new List<Task>();
                foreach (var (key, value) in itemsBucket)
                {
                    parallelJobs.Add(_cosmosContainer.CreateItemStreamAsync(value, key).ContinueWith( x => {
                        var response = x.Result;
                        Console.WriteLine($"Import {response.ClientRequestId} has status {response.Status} with message {response.Headers}");
                    }));
                }
                await Task.WhenAll(parallelJobs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return "import";
        }

        public void printConfig()
        {
            Console.WriteLine(JsonSerializer.Serialize(_cosmosDbConfig));
        }
        
    }
}