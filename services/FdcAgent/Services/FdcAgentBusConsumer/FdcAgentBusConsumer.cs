using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reactive;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Reactive.Disposables;

namespace FdcAgent.Services.FoodBusService
{
    public static class FdcAgentBusConsumerExtension
    {
        public static void AddFdcAgentBusConsumerService(this IServiceCollection services)
        {
            services.AddScoped<IFdcAgentBusConsumer, FdcBusConsumer>();
        }
    }
    public class FdcBusConsumer : IDisposable, IFdcAgentBusConsumer
    {
        private IDisposable _foodSubscription;
        private IFdcAgentBus _fdcBus;

        public FdcBusConsumer(IFdcAgentBus fdcBus)
        {
            _fdcBus = fdcBus;
        }

        public void Dispose()
        {
            _foodSubscription.Dispose();
        }

        public void ConsoleLogger()
        {
            _foodSubscription = _fdcBus.FoodBus.Subscribe( id => {
                System.Console.WriteLine($"Logging message: {id.FdcId} at " + DateTime.Now);
            });
            
        }
    }
}