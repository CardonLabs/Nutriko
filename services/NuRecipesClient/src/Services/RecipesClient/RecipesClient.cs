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

}