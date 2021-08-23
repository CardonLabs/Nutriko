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

namespace FdcAgent.Services.FoodBusService
{
    public interface IFdcAgentBus
    {
        void PublishMessage(FdcAgentMessage message);
        void PublishFdcMessage(SRLegacyFoodItem message);
        void AllItemsProcessed();
        IObservable<FdcAgentMessage> FoodBus{ get; }
        IObservable<SRLegacyFoodItem> FoodBusFdc{ get; }
    }
}