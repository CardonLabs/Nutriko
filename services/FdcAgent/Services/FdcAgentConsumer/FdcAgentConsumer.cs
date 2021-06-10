using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
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
    public static class FdcAgentFoodConsumerExtension
    {
        public static void AddFdcAgentFoodConsumerService(this IServiceCollection services)
        {
            services.AddScoped<IFdcAgentFoodConsumer, FdcAgentFoodConsumer>();
        }
    }
    public class FdcAgentFoodConsumer : IFdcAgentFoodConsumer, IDisposable
    {
        private ILogger<FdcAgentFoodConsumer> _logger;
        private IDisposable _subscription;
        private IDisposable _sub2;
        IFdcAgentFoodStream mem;

        public FdcAgentFoodConsumer(ILogger<FdcAgentFoodConsumer> logger, IFdcAgentFoodStream messageStream) 
        {
            _logger = logger;
            mem = messageStream;
            //_sub2 = messageStream.legacyMessageRx().Subscribe();
            _subscription = messageStream.legacyMessageRx().Subscribe( x => { EchoMsg(x.FdcId);});
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }

        private void EchoMsg(int msg)
        {
            System.Console.WriteLine("echomsg FUNC:" + msg);
        }

        public void test()
        {
            _sub2 = mem.legacyMessageRx().Skip<FdcLegacyMessage>(5).Subscribe( x => {
                System.Console.WriteLine("subscriber 2: ---- " + x.FdcId);
            });
        }

    }

}