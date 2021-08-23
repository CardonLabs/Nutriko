using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using FdcAgent.Models.FdcShemas;
using FdcAgent.Models.FdcShemas.FdcSyncOptions;
using FdcAgent.Services.FoodBusService;

namespace FdcAgent.Services.FoodStreamService
{
    public static class FdcAgentHttpClientExtension
    {
        public static void AddFdcAgentHttpClientService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DataSources>(
                configuration.GetSection("DataSources")
            );

            services.AddHttpClient<IFdcAgentHttpClient, FdcAgentHttpClient>();
        }
    }
    public class FdcAgentHttpClient : IFdcAgentHttpClient
    {
        private readonly DataSources _dataSources;
        private readonly ILogger<FdcAgentHttpClient> _log;
        private IFdcAgentBus _messageBusFdc;
        public HttpClient _client { get; }
        private FdcAgentHttpStatus _operationStatus;

        public FdcAgentHttpClient(HttpClient client, IOptions<DataSources> dataSources, ILogger<FdcAgentHttpClient> log, IFdcAgentBus messageBusFdc)
        {
            _dataSources = dataSources.Value;
            _log = log;
            _messageBusFdc = messageBusFdc;

            client.BaseAddress = new Uri(_dataSources.Usda.FoodDataCentral.BaseUrl);
            _client = client;
        }

        public async Task<FdcAgentHttpStatus> GetFoods(IList<int> fdcIds)
        {
            FdcRequestParams fdc = new FdcRequestParams(){
                fdcIds = fdcIds,
                format = _dataSources.Usda.RequestBody.format,
                nutrients = _dataSources.Usda.RequestBody.nutrients
            };

            _operationStatus = new FdcAgentHttpStatus(); 

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var fdcJsonContent = new StringContent(
                JsonSerializer.Serialize<FdcRequestParams>(fdc, options), 
                Encoding.UTF8, 
                "application/json"
            );
            
            var response = await _client.PostAsync(
                _dataSources.Usda.FoodDataCentral.Endpoints.Foods + _dataSources.Usda.FoodDataCentral.Key,
                fdcJsonContent
            );

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var jsonItems =  await JsonSerializer.DeserializeAsync<IList<SRLegacyFoodItem>>(responseStream, options);
            
            foreach (var item in jsonItems)
            {
                _messageBusFdc.PublishFdcMessage(item);
                _operationStatus.count++;
            }
            _operationStatus.message = $"Proccessed {_operationStatus.count}...";

            return _operationStatus;
        }
    }
}