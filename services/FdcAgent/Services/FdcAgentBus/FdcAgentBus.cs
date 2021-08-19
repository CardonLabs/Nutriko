using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reactive;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace FdcAgent.Services.FoodBusService
{
    public static class FdcAgentBusExtension
    {
        public static void AddFdcAgentBusService(this IServiceCollection services)
        {
            services.AddScoped<IFdcAgentBus, FdcAgentBus>();
        }
    }

    public class FdcAgentBus : IFdcAgentBus
    {
        private Subject<FdcAgentMessage> _foodBus;
        public IObservable<FdcAgentMessage> FoodBus => _foodBus;

        public FdcAgentBus()
        {
            _foodBus = new Subject<FdcAgentMessage>();
        }

        public void AllItemsProcessed() 
        {
            _foodBus.OnCompleted();
        }

        public void PublishMessage(FdcAgentMessage message)
        {
            try
            {
                _foodBus.OnNext(message);
            }
            catch (Exception e)
            {
                _foodBus.OnError(e);
            }

        }
    }
}