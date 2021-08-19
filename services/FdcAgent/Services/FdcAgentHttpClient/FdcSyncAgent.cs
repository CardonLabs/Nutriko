using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FdcAgent.Models.FdcShemas.FdcSyncOptions
{
    public class DataSources {
        public Usda Usda { get; set; }
    }

    public class Usda {
        public FoodDataCentral FoodDataCentral { get; set; }
        public RequestBody RequestBody { get; set; }
    }

    public class FoodDataCentral
    {
        public string BaseUrl { get; set; }
        public string Key { get; set; }
        
        public Endpoint Endpoints { get; set; }
    }
    public class Endpoint
    {
        public string Foods { get; set; }
        public string Search { get; set; }
        public string List { get; set; }
    }

    public class RequestBody 
    {
        public string format { get; set; }
        public int[] nutrients { get; set; }
    }

    public class FdcRequestParams
    {
        public Array fdcIds { get; set; }
        public string format { get; set; }
        public Array nutrients { get; set; }
    }
}