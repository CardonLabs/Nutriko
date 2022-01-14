using System;
using System.Collections.Generic;
using Azure.Cosmos;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NuRecipesClient.Services.RecipesServiceReader
{
    public class RecipesReaderConfig {
        public string endPointUrl { get; set; }
        public string authorizationKey { get; set; }
        public string databaseId { get; set; }
        public string containerId { get; set; }
        public string partitionKey { get; set; }
        public string applicationRegion { get; set; }
        public int pageSize { get; set; }
    }

    public class ContinuationToken
    {
        [JsonPropertyName("Version")]
        public string Version { get; set; }

        [JsonPropertyName("QueryPlan")]
        public string QueryPlan { get; set; }

        [JsonPropertyName("SourceContinuationToken")]
        public string SourceContinuationToken { get; set; }
    }
}