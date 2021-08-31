
using System;
using System.Collections.Generic;

namespace FdcAgent.Services.CosmosClientService
{
    public class FdcAgentCosmosDbConfig {
        public string endPointUrl { get; set; }
        public string authorizationKey { get; set; }
        public string databaseId { get; set; }
        public string containerId { get; set; }
        public string partitionKey { get; set; }
        public string applicationRegion { get; set; }
    }
}