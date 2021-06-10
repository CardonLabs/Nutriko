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

namespace FdcAgent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FdcAgentController : ControllerBase
    {
        private readonly ILogger<FdcAgentFoodConsumer> _logger;
        private IFdcAgentBlobParser _blobParser;
        private IFdcAgentFoodConsumer _msgConsumer;
        private IFdcAgentHttpClient _httpClient;

        public FdcAgentController(ILogger<FdcAgentFoodConsumer> logger, IFdcAgentBlobParser blobParser, IFdcAgentFoodConsumer msgConsumer, IFdcAgentHttpClient httpClient)
        {
            _logger = logger;
            _blobParser = blobParser;
            _msgConsumer = msgConsumer;
            _httpClient = httpClient;
        }

        [HttpGet]
        public string Get()
        {
            var test = _blobParser.ReadBlob();
            return "Works";
        }

        [HttpGet("getinfo")]
        public Task<string> GetInfo()
        {
            var test = _blobParser.ReadBlob();
            return test;
        }

        [HttpGet("getmsg")]
        public string GetMsg()
        {
            var test = _blobParser.ReadBlob();
            _msgConsumer.test();
            _msgConsumer.Dispose();
            return "messages";
        }

        [HttpGet("GetFoods")]
        public async Task<dynamic> GetFoods()
        {
            var res = await _httpClient.GetFoods(new int[] {171705, 169760});

            return JsonSerializer.Serialize(res);
        }

    }
}
