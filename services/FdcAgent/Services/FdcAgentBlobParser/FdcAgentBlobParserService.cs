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
using FdcAgent.Services.FoodBusService;

using FdcAgent.Models.FdcShemas;

namespace FdcAgent.Services.BlobParserService
{
    public static class FdcAgentBlobParserExtension
    {
        public static void AddFdcAgentBlobParserService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FdcAgentBlobConfig>(
                configuration.GetSection("BlobStorage")
            );

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
        private IFdcAgentBus _messageBus;
        private FdcAgentParserStatus _operationStatus;

        public FdcAgentBlobParser(ILogger<FdcAgentBlobParser> logger, IOptions<FdcAgentBlobConfig> blobConfig, IFdcAgentBus messageBus)
        {
            _log = logger;
            _storageConfig = blobConfig.Value;
            _serviceClient = new BlobServiceClient(_storageConfig.connectionString);
            _container = _serviceClient.GetBlobContainerClient(_storageConfig.container);
            _messageBus = messageBus;
        }

        public async Task<FdcAgentParserStatus> ReadBlob()
        {
            _operationStatus = new FdcAgentParserStatus();
            _client = _container.GetBlobClient(_storageConfig.blob);

            FdcAgentMessage message = new FdcAgentMessage();

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
                        _messageBus.PublishMessage(message);
                        _operationStatus.count++;
                    }
                    
                }
                _messageBus.AllItemsProcessed();

            }

            _operationStatus.message = "Completed publishing items to observable";

            return _operationStatus;
            
        }
    }
}