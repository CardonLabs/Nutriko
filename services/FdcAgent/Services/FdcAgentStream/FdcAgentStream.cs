using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reactive;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using FdcAgent.Models.FdcShemas;

namespace FdcAgent.Services.FoodStreamService
{
    public static class FdcAgentFoodStreamExtension
    {
        public static void AddFdcAgentFoodStreamService(this IServiceCollection services) //, IConfiguration configuration)
        {
            services.AddScoped<IFdcAgentFoodStream, FdcAgentFoodStream>();
        }
    }
    public class FdcAgentFoodStream : IFdcAgentFoodStream
    {
        public Subject<FdcLegacyMessage> _legacyMessageSubject;

        public FdcAgentFoodStream()
        {
            _legacyMessageSubject = new Subject<FdcLegacyMessage>();
        }

        public IObservable<FdcLegacyMessage> legacyMessageRx()
        {
            return _legacyMessageSubject.AsObservable<FdcLegacyMessage>();
        }

        public void Publish(FdcLegacyMessage legacyMessage)
        {
            _legacyMessageSubject.OnNext(legacyMessage);
        }
    }
}