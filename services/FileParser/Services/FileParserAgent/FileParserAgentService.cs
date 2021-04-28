using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace FileParser.Services.FileParserAgentService
{
    public class FileParserAgentService : IFileParserAgentService
    {
        private readonly ILogger<FileParserAgentService> _log;
        public HttpClient Client { get; }

        public FileParserAgentService ( ) { }
        
    }
}