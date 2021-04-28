using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FileParser.Models.FdcShemas.SrLegacy
{
    public class SrLegacyFoodItem
    {
        public int fdcId { get; set; }
        public string fdc_id { get; set; }
    }
}