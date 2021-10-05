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

namespace NuRecipes.Services.Recipes
{
    public static class NuRecipesExtension
    {
        public static void AddNuRecipesService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DataSources>(
                configuration.GetSection("DataSources")
            );

            services.AddScoped<IRecipesClient, RecipesClient>();
        }
    }
    public class RecipesClient : IRecipesClient
    {
        public RecipesClient()
        {
            
        }

    }
}