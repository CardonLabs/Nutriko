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

using FileParser.Services.FileParserAgentService;
using FileParser.Models.FileParserAgentService;

namespace FileParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileParserController : ControllerBase
    {
        private FileParserAgentService fileParserAgentService;
        private BlobStorageConfig _config;
        private ILogger<FileParserAgentService> _logger;
        public FileParserController( IOptions<BlobStorageConfig> config, ILogger<FileParserAgentService> logger)
        {   
            _config = config.Value;
            _logger = logger;
        }

        [HttpGet("ReadBlob")]
        public async Task ReadBlob()
        {
            await fileParserAgentService.ReadBlob();
        }

        [HttpGet("test")]
        public async Task<dynamic> test()
        {
            var conf = _config;

            _logger.LogInformation(_config.connectionString);

            return  JsonSerializer.Serialize(conf);
            
        }
    }
}