using System.Collections.Generic;
using System.Threading.Tasks;

using FoodCentralSync.Models.FdcShemas.SrLegacy;

namespace FoodCentralSync.Services.FdcSyncAgentService
{
    public interface IFdcSyncAgentService {
        Task<IList<SRLegacyFoodItem>> GetFoods(int[] fdcIds);
        
    }
}