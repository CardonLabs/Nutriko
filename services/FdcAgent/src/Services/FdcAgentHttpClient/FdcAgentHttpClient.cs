using System;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
using Azure;
using Azure.Core;

using FdcAgent.Models.FdcShemas;
using FdcAgent.Models.FdcShemas.FdcSyncOptions;
using FdcAgent.Models.FdcShemas.Nutriko;
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
        private readonly ILogger<FdcAgentHttpClient> _logger;
        private IFdcAgentBus _messageBusFdc;
        public HttpClient _client { get; }
        private JsonSerializerOptions _options = new JsonSerializerOptions{
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        private FdcAgentHttpStatus _operationStatus;

        public FdcAgentHttpClient(HttpClient client, IOptions<DataSources> dataSources, ILogger<FdcAgentHttpClient> log, IFdcAgentBus messageBusFdc)
        {
            _dataSources = dataSources.Value;
            _logger = log;
            _messageBusFdc = messageBusFdc;

            client.BaseAddress = new Uri(_dataSources.Usda.FoodDataCentral.BaseUrl);
            _client = client;
        }

        public async Task<FdcAgentHttpStatus> GetFdcFoodItems(IList<int> fdcIds)
        {
            var semaphoreSlim = new SemaphoreSlim(
                initialCount: 10,
                maxCount: 10
            );

            var responses = new ConcurrentBag<NuFoodItem>();
            var httpTasks = new List<Task>();

            foreach (var id in fdcIds)
            {
                httpTasks.Add(
                    Task.Run( async() => {
                        await semaphoreSlim.WaitAsync();
                        try
                        {
                            _logger.LogInformation($"Requesting item id: {id} - at {DateTime.Now}");

                            FdcRequestParams requestParams = new FdcRequestParams(){
                                fdcIds = new List<int> { id },
                                format = _dataSources.Usda.RequestBody.format,
                                nutrients = _dataSources.Usda.RequestBody.nutrients
                            };

                            var content = new StringContent(
                                JsonSerializer.Serialize<FdcRequestParams>(requestParams, _options), 
                                Encoding.UTF8, 
                                "application/json"
                            );

                            var response = await _client.PostAsync(
                                _dataSources.Usda.FoodDataCentral.Endpoints.Foods + _dataSources.Usda.FoodDataCentral.Key,
                                content
                            );
                            response.EnsureSuccessStatusCode();

                            _logger.LogInformation($"Delaying request for throttling");
                            await Task.Delay(TimeSpan.FromSeconds(3));

                            using var responseStream = await response.Content.ReadAsStreamAsync();
                            var item =  await JsonSerializer.DeserializeAsync<IList<SRLegacyFoodItem>>(responseStream, _options);

                            if (item != null)
                            {
                                _logger.LogInformation($"********** {item[0].fdcId}");

                                if(item[0].foodPortions == null)
                                     _logger.LogInformation($" ####### {item[0].fdcId} #### - no portions");

                                NuFoodItem nuFoodItem = this.TransformItem(item[0]);
                                _messageBusFdc.PublishFdcMessage(nuFoodItem);
                                responses.Add(nuFoodItem);
                                
                                _logger.LogInformation($"Task end");
                                
                            }
                            
                        }
                        finally
                        {
                            semaphoreSlim.Release();
                        }
                    })
                );
                
            } 
            await Task.WhenAll(httpTasks);

            /*
            ** Much better work to do here
            ** TODO: Better return and checking for data errors
            */
            _operationStatus = new FdcAgentHttpStatus();
            _operationStatus.count = httpTasks.Count;
            _operationStatus.message = "OK";
            
            return _operationStatus;
        }

        private NuFoodItem TransformItem(SRLegacyFoodItem item)
        {
            IList<NuFoodNutrient> nutrients = new List<NuFoodNutrient>();
            foreach (var nutrient in item.foodNutrients)
            {
                NuFoodNutrient nu = new NuFoodNutrient {
                    id = nutrient.nutrient.id,
                    name = nutrient.nutrient.name,
                    number = nutrient.nutrient.number,
                    unitName = nutrient.nutrient.unitName,
                    amount = nutrient.amount
                };
                nutrients.Add(nu);
            }

            IList<NuFoodPortion> portions = new List<NuFoodPortion>();
            if(item.foodPortions == null)
            {
                NuFoodPortion por = new NuFoodPortion {
                    name = "",
                    gramWeight = 0,
                    amount = 0
                };
                portions.Add(por);

            }

            if(item.foodPortions != null)
            {
                foreach (var portion in item.foodPortions)
                {
                    NuFoodPortion por = new NuFoodPortion {
                        name = portion.modifier,
                        gramWeight = portion.gramWeight,
                        amount = portion.amount
                    };
                    portions.Add(por);
                }
            }

            NuFoodItem foodItem = new NuFoodItem {
                id = item.fdcId.ToString(),
                type = "food",
                dataType = item.dataType,
                category = item.foodCategory.description,
                name = item.description,
                publicationDate = item.publicationDate,
                foodNutrients = nutrients,
                foodPortions = portions,
                nutrientConversionFactors = new NuNutrientConversionFactors {
                    proteinConversionFactor = new NuProteinConversionFactor(),
                    calorieConversionFactor = new NuCalorieConversionFactor()
                }

            };

            foreach (var factor in item.nutrientConversionFactors)
            {
                if(factor.type == ".ProteinConversionFactor")
                {
                    foodItem.nutrientConversionFactors.proteinConversionFactor.type = factor.type;
                    foodItem.nutrientConversionFactors.proteinConversionFactor.name = factor.name;
                    foodItem.nutrientConversionFactors.proteinConversionFactor.value = factor.value;
                }

                if(factor.type == ".CalorieConversionFactor")
                {
                    foodItem.nutrientConversionFactors.calorieConversionFactor.type = factor.type;
                    foodItem.nutrientConversionFactors.calorieConversionFactor.name = factor.name;
                    foodItem.nutrientConversionFactors.calorieConversionFactor.proteinValue = factor.proteinValue;
                    foodItem.nutrientConversionFactors.calorieConversionFactor.fatValue = factor.fatValue;
                    foodItem.nutrientConversionFactors.calorieConversionFactor.carbohydrateValue = factor.carbohydrateValue;
                }
            }

            return foodItem;
        }

    }
}