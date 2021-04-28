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

namespace FileParser.Services.FileParserPublisherService
{
    public class FileParserPublisherService : IFileParserPublisherService
    {
        private readonly ILogger<FileParserPublisherService> _log;
        public HttpClient Client { get; }

        public FileParserPublisherService ( ) { }
        
    }
}