
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Subjects;
using System.Reactive.Concurrency;
using FdcAgent.Models.FdcShemas;

namespace FdcAgent.Services.CosmosClientService
{
    public interface IFdcAgentCosmosClient
    {
        //void EchoMessage();
        //void EchoMsg(int msg);
        //Task EchoMsgItem(FdcLegacyMessage message);
        void printConfig();
        Task<dynamic> StartImport(IList<SRLegacyFoodItem> fdcFoodList);
    }
}