using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NuRecipesClient.Models.Options
{
    public class NuEventHub
    {
        public string EndPoint { get; set; }
        public string HubName { get; set; }

    }
}