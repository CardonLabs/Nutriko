using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using NuRecipesAgent.Services.Recipes;

namespace NuRecipesAgent
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IRecipesAgent _recipesAgent;
        

        public Worker(ILogger<Worker> logger, IRecipesAgent recipesAgent)
        {
            _logger = logger;
            _recipesAgent = recipesAgent;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Recipes Worker running at: {time}", DateTimeOffset.Now);
                await _recipesAgent.StartListening(stoppingToken);

            }
        }
    }
}
