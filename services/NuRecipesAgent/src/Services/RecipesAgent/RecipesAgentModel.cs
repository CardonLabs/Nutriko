using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NuRecipesAgent.Models.Options
{
    public class Resources
    {
        public EventHub eventHub { get; set; }
        public BlobStorage blobStorage { get; set; }

    }
    public class EventHub
    {
        public string EndPoint { get; set; }
        public string HubName { get; set; }
        public string ConsumerGroup { get; set; }

    }

    public class BlobStorage
    {
        public string EndPoint { get; set; }
        public string Container { get; set; }
    }
}