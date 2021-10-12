using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

using NuRecipesAgent.Models.Options;

namespace NuRecipesAgent.Services.Recipes
{
    public static class RecipesAgentExtension
    {
        public static void AddRecipesAgentService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Resources>(
                configuration.GetSection("Resources")
            );

            services.AddTransient<IRecipesAgent, RecipesAgent>();
        }
    }
    public class RecipesAgent : IRecipesAgent
    {
        private ILogger<RecipesAgent> _logger;
        private Resources _resources;
        public RecipesAgent( ILogger<RecipesAgent> logger, IOptions<Resources> options)
        {
            _logger = logger;
            _resources = options.Value;

        }

        public string PrintConfig()
        {
            return JsonSerializer.Serialize(_resources);
        }
    }

}