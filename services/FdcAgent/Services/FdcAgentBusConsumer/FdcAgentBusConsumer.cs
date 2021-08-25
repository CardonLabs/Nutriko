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

using FdcAgent.Models.FdcShemas;

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
        private IDisposable _foodItemsSubscription;
        private IFdcAgentBus _fdcBus;
        private IList<int> _fdcIdList;
        private IList<SRLegacyFoodItem> _fdcFoodItemList;

        public FdcBusConsumer(IFdcAgentBus fdcBus)
        {
            _fdcBus = fdcBus;
        }

        public void Dispose()
        {
            if (_foodSubscription != null)
                _foodSubscription.Dispose();
        }

        public void DisposeFood()
        {
            if (_foodItemsSubscription != null)
                _foodItemsSubscription.Dispose();
        }

        public IList<int> SubscribeFdcIds()
        {
            _fdcIdList = new List<int>();

            _foodSubscription = _fdcBus.FoodBus.Subscribe( ids => {
                _fdcIdList.Add(ids.FdcId);
            }); 

            return _fdcIdList;

        }

        public IList<SRLegacyFoodItem> SubscribeFdcFoods()
        {
            _fdcFoodItemList = new List<SRLegacyFoodItem>();

            _foodItemsSubscription = _fdcBus.FoodBusFdc.Subscribe( item => {
                _fdcFoodItemList.Add(item);
            });

            return _fdcFoodItemList;
        }
    }
}