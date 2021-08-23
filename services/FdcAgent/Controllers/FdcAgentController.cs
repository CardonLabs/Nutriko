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
            IList<int> list = new List<int>();

            list = _msgConsumer.GetFdcIds();
            var parserReply = await _blobParser.ReadBlob();
            _msgConsumer.Dispose();

            dynamic items = await GetFoods(list);

            return new OkObjectResult(JsonSerializer.Serialize(parserReply));
        }

        [HttpGet("agent/getfoods")]
        private async Task<IActionResult> GetFoods(IList<int> idList)
        {
            var res = await _httpClient.GetFoods(idList);
            Console.WriteLine("Requesting items to remote API...");

            return new OkObjectResult(JsonSerializer.Serialize(res));
        }

        // TEST ACTIONS ------------------------------------------

        [HttpGet("test/getfoods")]
        public async Task<IActionResult> testGetFoods(IList<int> idList)
        {
            var res = await _httpClient.GetFoods(new List<int> {171705, 169760});
            Console.WriteLine("Requesting items to remote API...");

            return new OkObjectResult(JsonSerializer.Serialize(res));
        }
        [HttpGet("test/echo")]
        public async Task<IActionResult> Log()
        {
            IList<int> list = new List<int>();

            list = _msgConsumer.GetFdcIds();
            var parserReply = await _blobParser.ReadBlob();
            _msgConsumer.Dispose();

            foreach (var item in list)
            {
                _logger.LogInformation($"Heard ID: {item}");
            }

            return new OkObjectResult(JsonSerializer.Serialize(parserReply));
        }

    }
}
