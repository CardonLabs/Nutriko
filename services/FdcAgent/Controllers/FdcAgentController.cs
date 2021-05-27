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

namespace FdcAgent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FdcAgentController : ControllerBase
    {
        private readonly ILogger<FdcAgentController> _logger;
        private IFdcAgentBlobParser _blobParser;

        public FdcAgentController(ILogger<FdcAgentController> logger, IFdcAgentBlobParser blobParser)
        {
            _logger = logger;
            _blobParser = blobParser;
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

    }
}
