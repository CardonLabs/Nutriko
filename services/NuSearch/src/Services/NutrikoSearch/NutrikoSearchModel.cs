using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace NuSearch.Models.Search.Operator
{
    public class AzureSearch
    {
        public string Endpoint { get; set; }
        public string Apikey { get; set; }
        public Options Options { get; set; }
    }

    public class Options
    {
        public string Index { get; set; }
    }
    
}