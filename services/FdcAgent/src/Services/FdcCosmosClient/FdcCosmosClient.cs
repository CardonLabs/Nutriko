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
        private ILogger<FdcAgentCosmosClient> _logger;
        private readonly FdcAgentCosmosDbConfig _cosmosDbConfig;
        private static CosmosClient _cosmosClient = null;
        private static readonly CosmosClientOptions _cosmosClientOptions = new CosmosClientOptions {
            MaxRetryAttemptsOnRateLimitedRequests = 9,
            MaxRetryWaitTimeOnRateLimitedRequests = TimeSpan.FromSeconds(60)
        };
        private CosmosDatabase _cosmosDatabase = null;
        private CosmosContainer _cosmosContainer = null;
        private IFdcAgentBusConsumer _messageConsumer;
        //private IList<SRLegacyFoodItem> _itemsList;

        public FdcAgentCosmosClient(ILogger<FdcAgentCosmosClient> logger, IOptions<FdcAgentCosmosDbConfig> options, IFdcAgentBusConsumer messageConsumer)
        {
            _logger = logger;
            _messageConsumer = messageConsumer;
            _cosmosDbConfig = options.Value;
            _cosmosClient = new CosmosClient(_cosmosDbConfig.endPointUrl, _cosmosDbConfig.authorizationKey, _cosmosClientOptions);
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
            
            var semaphoreSlim = new SemaphoreSlim(
                initialCount: 10,
                maxCount: 10
            );

            try
            {
                var itemsBucket = new List<KeyValuePair<PartitionKey, Stream>>();
                foreach (var item in list)
                {
                    var stream = new MemoryStream();
                    await JsonSerializer.SerializeAsync<NuFoodItem>(stream, item);

                    itemsBucket.Add(new KeyValuePair<PartitionKey, Stream>(new PartitionKey(item.type), stream));
                }

                var parallelJobs = new List<Task>();
                foreach (var (key, value) in itemsBucket)
                {
                    parallelJobs.Add(
                        Task.Run( async () => {
                            await semaphoreSlim.WaitAsync();

                            try
                            {
                                await Task.Delay(TimeSpan.FromMilliseconds(200));

                                Response response = await _cosmosContainer.CreateItemStreamAsync(value, key);
                                string retryAfterMs = null;
                                response.Headers.TryGetValue("x-ms-retry-after-ms", out retryAfterMs);

                                _logger.LogInformation($"Response: {response.Status}");

                                if (retryAfterMs != null)
                                {
                                    _logger.LogInformation($"Delaying by additional: {retryAfterMs}");
                                    await Task.Delay(TimeSpan.FromMilliseconds(double.Parse(retryAfterMs)));
                                    await _cosmosContainer.CreateItemStreamAsync(value, key);
                                }
                                 
                            }
                            finally
                            {
                                semaphoreSlim.Release();
                            }
                            
                        })
                    );
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