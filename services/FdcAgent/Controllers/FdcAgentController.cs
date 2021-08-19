using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Text.Json;

using FdcAgent.Services.BlobParserService;
using FdcAgent.Services.FoodStreamService;
using FdcAgent.Services.FoodBusService;
using FdcAgent.Models.FdcShemas;

namespace FdcAgent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FdcAgentController : ControllerBase
    {
        private readonly ILogger<FdcAgentController> _logger;
        private IFdcAgentBlobParser _blobParser;
        private IFdcAgentBusConsumer _msgConsumer;
        private IFdcAgentHttpClient _httpClient;

        public FdcAgentController(ILogger<FdcAgentController> logger, IFdcAgentBlobParser blobParser, IFdcAgentBusConsumer msgConsumer, 
                IFdcAgentHttpClient httpClient)
        {
            _logger = logger;
            _blobParser = blobParser;
            _msgConsumer = msgConsumer;
            _httpClient = httpClient;
        }

        [HttpPost("agent/import")]
        public async Task<IActionResult> AgentImport()
        {
            _msgConsumer.ConsoleLogger();
            var parserReply = await _blobParser.ReadBlob();
            _msgConsumer.Dispose();
            

            return new OkObjectResult(JsonSerializer.Serialize(parserReply));
        }

        [HttpGet("GetFoods")]
        public async Task<dynamic> GetFoods()
        {
            var res = await _httpClient.GetFoods(new int[] {171705, 169760});

            return JsonSerializer.Serialize(res);
        }

    }
}
