using System.Collections.Generic;
using System.Threading.Tasks;

using FdcAgent.Models.FdcShemas;
using FdcAgent.Models.FdcShemas.Nutriko;

namespace FdcAgent.Services.FoodStreamService
{
    public interface IFdcAgentHttpClient {
        //Task<FdcAgentHttpStatus> GetFoods(IList<int> fdcIds);
        Task<FdcAgentHttpStatus> GetFdcFoodItems(IList<int> fdcIds);
        
    }
}