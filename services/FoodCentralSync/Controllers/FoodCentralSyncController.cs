using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

using FoodCentralSync.Models.FdcShemas.SrLegacy;
using FoodCentralSync.Services.FdcSyncAgentService;

namespace FoodCentralSync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCentralSyncController : ControllerBase
    {
        private readonly IFdcSyncAgentService _fss;
        private readonly ILogger<FoodCentralSyncController> _log;
        public FoodCentralSyncController(IFdcSyncAgentService fss, ILogger<FoodCentralSyncController> log) 
        {
            _log = log;
            _fss = fss;
        }

        [HttpGet("GetFoods")]
        public async Task<dynamic> GetFoods()
        {
            var res = await _fss.GetFoods(new int[] {171705, 171513, 169760});

            return JsonSerializer.Serialize(res);
        }


    }
}