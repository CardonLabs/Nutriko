using System;
using System.IO;
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
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using FileParser.Models.FileParserAgentService;

namespace FileParser.Services.FileParserAgentService
{
    public class FileParserAgentService : IFileParserAgentService
    {
        private readonly ILogger<FileParserAgentService> _log;
        private readonly BlobStorageConfig _storageConfig;

        private BlobServiceClient _serviceClient;
        private BlobContainerClient _container;
        private BlobClient _client;


        public FileParserAgentService (ILogger<FileParserAgentService> logger, IOptions<BlobStorageConfig> storageConfig) 
        { 
            this._log = logger;
            this._storageConfig = storageConfig.Value;

            _serviceClient = new BlobServiceClient(_storageConfig.connectionString);
            _log.LogInformation("#####################" + _serviceClient.AccountName);
        }

        public async Task ReadBlob () 
        {
            _container = _serviceClient.GetBlobContainerClient(_storageConfig.container);
            _client = _container.GetBlobClient(_storageConfig.blob);

            var content = await _client.DownloadAsync();
            using (var stream = new StreamReader(content.Value.Content))
            {
                while (!stream.EndOfStream) 
                {
                    var line = await stream.ReadLineAsync();
                    _log.LogInformation(line);
                }
            }

            return content.Value.Content;

        }
        
    }
}