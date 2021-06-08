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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using CsvHelper;
using CsvHelper.Configuration;

using FdcAgent.Services.FoodStreamService;

using FdcAgent.Models.FdcShemas;

namespace FdcAgent.Services.BlobParserService
{
    public static class FdcAgentBlobParserExtension
    {
        public static void AddFdcAgentBlobParserService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFdcAgentBlobParser, FdcAgentBlobParser>();
        }
    }

    public class FdcAgentBlobParser : IFdcAgentBlobParser
    {
        private readonly ILogger<FdcAgentBlobParser> _log;
        private readonly FdcAgentBlobConfig _storageConfig;
        private BlobServiceClient _serviceClient;
        private BlobContainerClient _container;
        private BlobClient _client;
        private IFdcAgentFoodStream _legacyMessagePublisher;

        public FdcAgentBlobParser(ILogger<FdcAgentBlobParser> logger, IOptions<FdcAgentBlobConfig> blobConfig, IFdcAgentFoodStream legacyMessagePublisher)
        {
            _log = logger;
            _storageConfig = blobConfig.Value;
            _serviceClient = new BlobServiceClient(_storageConfig.connectionString);
            _container = _serviceClient.GetBlobContainerClient(_storageConfig.container);
            _legacyMessagePublisher = legacyMessagePublisher;
        }

        public async Task<string> ReadBlob()
        {
            _client = _container.GetBlobClient(_storageConfig.blob);

            FdcLegacyMessage message = new FdcLegacyMessage();

            var content = await _client.DownloadAsync();

            using (var stream = new StreamReader(content.Value.Content))
            using (var csv = new CsvReader(stream, System.Globalization.CultureInfo.CurrentCulture))
            {
                while (!stream.EndOfStream) 
                {
                    var rec = csv.GetRecords<CvsSrLegacyFoodItem>();

                    foreach (var item in rec)
                    {
                        message.FdcId = item.FdcId;
                        _legacyMessagePublisher.Publish(message);
                    }
                    
                }

            }

            return "someome";
            
        }
    }
}