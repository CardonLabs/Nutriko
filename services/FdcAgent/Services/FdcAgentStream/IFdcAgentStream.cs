using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Subjects;
using System.Reactive.Concurrency;
using FdcAgent.Models.FdcShemas;

namespace FdcAgent.Services.FoodStreamService
{
    public interface IFdcAgentFoodStream
    {
        void Publish(FdcLegacyMessage legacyMessage);
        IObservable<FdcLegacyMessage> legacyMessageRx();
        //void Subscribe(string subscriberName, Action<FdcLegacyMessage> action);
    }
}