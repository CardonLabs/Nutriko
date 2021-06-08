using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

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
        private FdcAgentFoodConsumer _consumer;

        public FdcAgentController(ILogger<FdcAgentFoodConsumer> logger, IFdcAgentBlobParser blobParser, FdcAgentFoodConsumer consumer)
        {
            _logger = logger;
            _blobParser = blobParser;
            _consumer = consumer;
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
            _consumer.test();
            _consumer.Dispose();
            return "messages";
        }

    }
}
