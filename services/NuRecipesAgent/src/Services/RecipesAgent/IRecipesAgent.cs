using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Processor;

namespace NuRecipesAgent.Services.Recipes
{
    public interface IRecipesAgent {
        Task StartListening(CancellationToken stoppingToken);

    }
}