using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

using NuRecipesAgent.Services.Recipes;
using NuRecipesAgent.Services.CosmosServiceClient;

namespace NuRecipesAgent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;

                    services.AddRecipesBusService();
                    services.AddRecipesCosmosClientExtension(configuration);
                    services.AddRecipesAgentService(configuration);
                    services.AddHostedService<Worker>();
                });
    }
}
