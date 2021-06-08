using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Subjects;
using System.Reactive.Concurrency;
using FdcAgent.Models.FdcShemas;

namespace FdcAgent.Services.FoodStreamService
{
    public interface IFdcAgentFoodConsumer
    {
        //void EchoMessage();
        //void EchoMsg(int msg);
        //Task EchoMsgItem(FdcLegacyMessage message);
        void test();
    }
}