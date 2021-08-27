using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reactive;
using System.Reactive.Subjects;
using System.Reactive.Linq;

using FdcAgent.Models.FdcShemas;
using FdcAgent.Models.FdcShemas.Nutriko;

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
        private Subject<NuFoodItem> _foodBusFdc;
        public IObservable<FdcAgentMessage> FoodBus => _foodBus;
        public IObservable<NuFoodItem> FoodBusFdc => _foodBusFdc;

        public FdcAgentBus()
        {
            _foodBus = new Subject<FdcAgentMessage>();
            _foodBusFdc = new Subject<NuFoodItem>();
        }

        public void AllItemsProcessed() 
        {
            _foodBus.OnCompleted();
        }

        public void FdcFoodListCompleted() 
        {
            _foodBusFdc.OnCompleted();
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

        public void PublishFdcMessage(NuFoodItem message)
        {
            try
            {
                _foodBusFdc.OnNext(message);
            }
            catch (Exception e)
            {
                
                _foodBusFdc.OnError(e);
            }
        }
    }
}