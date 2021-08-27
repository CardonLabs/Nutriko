using System;
using System.Globalization;
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
                foreach (var portion in item.foodPortions)
                {
                    NuFoodPortion por = new NuFoodPortion {
                        name = portion.modifier,
                        gramWeight = portion.gramWeight,
                        amount = portion.amount
                    };
                    portions.Add(por);
                }

                NuFoodItem foodItem = new NuFoodItem {
                    id = item.fdcId.ToString(),
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

                _messageBusFdc.PublishFdcMessage(foodItem);
                _operationStatus.count++;
            }
            _messageBusFdc.FdcFoodListCompleted();
            _operationStatus.message = $"Proccessed {_operationStatus.count}...";

            return _operationStatus;
        }
    }
}