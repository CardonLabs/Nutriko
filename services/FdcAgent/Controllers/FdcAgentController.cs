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
using FdcAgent.Services.CosmosClientService;
using FdcAgent.Models.FdcShemas;
using FdcAgent.Models.FdcShemas.Nutriko;

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
        private IFdcAgentCosmosClient _cosmosClient;

        public FdcAgentController(ILogger<FdcAgentController> logger, IFdcAgentBlobParser blobParser, IFdcAgentBusConsumer msgConsumer, 
                IFdcAgentHttpClient httpClient, IFdcAgentCosmosClient cosmosClient)
        {
            _logger = logger;
            _blobParser = blobParser;
            _msgConsumer = msgConsumer;
            _httpClient = httpClient;
            _cosmosClient = cosmosClient;
        }

        [HttpPost("agent/import")]
        public async Task<IActionResult> AgentImport()
        {
            IList<int> list = new List<int>();
            list = _msgConsumer.SubscribeFdcIds();

            IList<NuFoodItem> fdcFoodList = new List<NuFoodItem>();
            fdcFoodList = _msgConsumer.SubscribeFdcFoods();

            var parserReply = await _blobParser.ReadBlob();
            //var items = await _httpClient.GetFoods(list);
            dynamic t = await _cosmosClient.StartImport(fdcFoodList);

            _msgConsumer.Dispose();
            _msgConsumer.DisposeFood();

            return new OkObjectResult(JsonSerializer.Serialize(parserReply));
        }

        // [HttpGet("agent/getfoods")]
        // private async Task<IActionResult> GetFoods(IList<int> idList)
        // {
        //     var res = await _httpClient.GetFoods(idList);
        //     Console.WriteLine("Requesting items to remote API...");

        //     return new OkObjectResult(JsonSerializer.Serialize(res));
        // }

        // TEST ACTIONS ------------------------------------------

        [HttpGet("test/t1")]
        public async Task<IActionResult> testGetFoods()
        {
            IList<int> list = new List<int>();
            list = _msgConsumer.SubscribeFdcIds();

            IList<NuFoodItem> fdcFoodList = new List<NuFoodItem>();
            fdcFoodList = _msgConsumer.SubscribeFdcFoods();

            var parserReply = await _blobParser.ReadBlob();
            var items = await _httpClient.GetFoods2(list);
            dynamic t = await _cosmosClient.StartImport(fdcFoodList);

            _msgConsumer.Dispose();
            _msgConsumer.DisposeFood();

            foreach (var item in fdcFoodList)
            {
                Console.WriteLine($"Controller -- {item.id} -- {item.name}");
            }

            return new OkObjectResult(JsonSerializer.Serialize(parserReply));
        }
        [HttpGet("test/echo")]
        public async Task<IActionResult> Log()
        {
            IList<int> list = new List<int>();

            list = _msgConsumer.SubscribeFdcIds();
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
