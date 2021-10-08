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
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;

using NuRecipesClient.Models.Options;
using NuRecipesClient.Models.Recipes;
using NuRecipesClient.Models.Foods;

namespace NuRecipesClient.Services.Recipes
{
    public static class RecipesClientExtension
    {
        public static void AddRecipesClientService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<NuEventHub>(
                configuration.GetSection("Resources:EventHub")
            );

            services.AddScoped<IRecipesClient, RecipesClient>();
        }
    }
    public class RecipesClient : IRecipesClient
    {
        private readonly ILogger<RecipesClient> _logger;
        private NuEventHub _eventHubConfig;
        private static EventHubProducerClient _recipesHubClient;

        public RecipesClient(ILogger<RecipesClient> logger, IOptions<NuEventHub> options)
        {
            _logger = logger;
            _eventHubConfig = options.Value;
            _recipesHubClient = new EventHubProducerClient(_eventHubConfig.EndPoint);
            
        }

        public async Task PublishRecipeEvent(Recipe recipe, string eventType, string eventOperation)
        {
            await using (_recipesHubClient)
            {
                using EventDataBatch eventBatch = await _recipesHubClient.CreateBatchAsync();

                var eventBody = new BinaryData(recipe);
                var eventData = new EventData(eventBody);
                eventData.Properties.Add("type", eventType);
                eventData.Properties.Add("operation", eventOperation);

                eventBatch.TryAdd(eventData);
                try
                {
                    await _recipesHubClient.SendAsync(eventBatch);
                }
                finally
                {
                    await _recipesHubClient.DisposeAsync();
                }
            }

        }

    }

    public class MockRecipe
    {
        public Recipe recipe()
        {
            var item = new Recipe {
                id = Guid.NewGuid().ToString(),
                type = "recipe",
                details = new RecipeDetails {
                    id = Guid.NewGuid().ToString(),
                    name = "sample=1recipe",
                    description = "Sample desc",
                    cusine = "hispanic",
                    history = "history of food",
                    region = "latin america",
                    rating = "4",
                    popularity = "3"
                },
                directions = new List<RecipeDirections> {
                    new RecipeDirections {
                        id = "11111",
                        description = "Dir 1",
                        name = "Direction 1",
                        rank = "1"
                    }
                },
                steps = new List<RecipeSteps> {
                    new RecipeSteps {
                        id = "22222",
                        description = "step step step",
                        name = "Step 1",
                        rank = "2"
                    }
                },
                foods = new List<RecipeFoods> {
                    new RecipeFoods {
                        food = new FoodItem {
                            id = "167526",
                            type = "food",
                            dataType = "sr-legacy",
                            category = "Baked Products",
                            name = "Bread, Salvadoran Sweet Cheese (Quesadilla Salvadorena)",
                            publicationDate = "04-01-2019",
                            foodNutrients = new List<FoodNutrient> {
                                new FoodNutrient {id = 1008, name = "Energy", number = "208", unitName = "kcal", amount = 374},
                                new FoodNutrient {id = 1003, name = "Protein", number = "203", unitName = "g", amount = 7.12},
                                new FoodNutrient {id = 1004, name = "Total Lipid (Fat)", number = "204", unitName = "g", amount = 17.12},
                                new FoodNutrient {id = 1005, name = "Carbohydrate, By Difference", number = "205", unitName = "g", amount = 47.84},
                                new FoodNutrient {id = 1079, name = "Fiber, Total Dietary", number = "291", unitName = "g", amount = 0.7},
                                new FoodNutrient {id = 2000, name = "Sugars, Total Including Nlea", number = "269", unitName = "g", amount = 24.9}
                            },
                            foodPortions = new List<FoodPortion> {
                                new FoodPortion {gramWeight = 55, amount = 1, name = "Serving (Approximate Serving Size)"},
                                new FoodPortion {gramWeight = 399, amount = 1, name = "Cake Square (Average Weight Of Whole Item)"}
                            },
                            nutrientConversionFactors = new NutrientConversionFactors {
                                proteinConversionFactor = new ProteinConversionFactor {type = ".ProteinConversionFactor", value = 6.25, name = "Protein From Nitrogen"},
                                calorieConversionFactor = new CalorieConversionFactor {type = null, name = null, proteinValue = 0, fatValue = 0, carbohydrateValue = 0}
                            }
                        }
                    },
                    new RecipeFoods {
                        food = new FoodItem {
                            id = "167526",
                            type = "food",
                            dataType = "sr-legacy",
                            category = "Baked Products",
                            name = "Bread, Salvadoran Sweet Cheese (Quesadilla Salvadorena)",
                            publicationDate = "04-01-2019",
                            foodNutrients = new List<FoodNutrient> {
                                new FoodNutrient {id = 1008, name = "Energy", number = "208", unitName = "kcal", amount = 374},
                                new FoodNutrient {id = 1003, name = "Protein", number = "203", unitName = "g", amount = 7.12},
                                new FoodNutrient {id = 1004, name = "Total Lipid (Fat)", number = "204", unitName = "g", amount = 17.12},
                                new FoodNutrient {id = 1005, name = "Carbohydrate, By Difference", number = "205", unitName = "g", amount = 47.84},
                                new FoodNutrient {id = 1079, name = "Fiber, Total Dietary", number = "291", unitName = "g", amount = 0.7},
                                new FoodNutrient {id = 2000, name = "Sugars, Total Including Nlea", number = "269", unitName = "g", amount = 24.9}
                            },
                            foodPortions = new List<FoodPortion> {
                                new FoodPortion {gramWeight = 55, amount = 1, name = "Serving (Approximate Serving Size)"},
                                new FoodPortion {gramWeight = 399, amount = 1, name = "Cake Square (Average Weight Of Whole Item)"}
                            },
                            nutrientConversionFactors = new NutrientConversionFactors {
                                proteinConversionFactor = new ProteinConversionFactor {type = ".ProteinConversionFactor", value = 6.25, name = "Protein From Nitrogen"},
                                calorieConversionFactor = new CalorieConversionFactor {type = null, name = null, proteinValue = 0, fatValue = 0, carbohydrateValue = 0}
                            }
                        }
                    },
                    new RecipeFoods {
                        food = new FoodItem {
                            id = "167526",
                            type = "food",
                            dataType = "sr-legacy",
                            category = "Baked Products",
                            name = "Bread, Salvadoran Sweet Cheese (Quesadilla Salvadorena)",
                            publicationDate = "04-01-2019",
                            foodNutrients = new List<FoodNutrient> {
                                new FoodNutrient {id = 1008, name = "Energy", number = "208", unitName = "kcal", amount = 374},
                                new FoodNutrient {id = 1003, name = "Protein", number = "203", unitName = "g", amount = 7.12},
                                new FoodNutrient {id = 1004, name = "Total Lipid (Fat)", number = "204", unitName = "g", amount = 17.12},
                                new FoodNutrient {id = 1005, name = "Carbohydrate, By Difference", number = "205", unitName = "g", amount = 47.84},
                                new FoodNutrient {id = 1079, name = "Fiber, Total Dietary", number = "291", unitName = "g", amount = 0.7},
                                new FoodNutrient {id = 2000, name = "Sugars, Total Including Nlea", number = "269", unitName = "g", amount = 24.9}
                            },
                            foodPortions = new List<FoodPortion> {
                                new FoodPortion {gramWeight = 55, amount = 1, name = "Serving (Approximate Serving Size)"},
                                new FoodPortion {gramWeight = 399, amount = 1, name = "Cake Square (Average Weight Of Whole Item)"}
                            },
                            nutrientConversionFactors = new NutrientConversionFactors {
                                proteinConversionFactor = new ProteinConversionFactor {type = ".ProteinConversionFactor", value = 6.25, name = "Protein From Nitrogen"},
                                calorieConversionFactor = new CalorieConversionFactor {type = null, name = null, proteinValue = 0, fatValue = 0, carbohydrateValue = 0}
                            }
                        }
                    }
                }
            };

            return item;

        }
    }
}