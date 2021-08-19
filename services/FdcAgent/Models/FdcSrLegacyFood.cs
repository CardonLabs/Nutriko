using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

using CsvHelper.Configuration.Attributes;

namespace FdcAgent.Models.FdcShemas
{
    public class CvsSrLegacyFoodItem
    {
        [Index(0)]
        [Name("fdc_id")]
        public int FdcId { get; set; }

        [Index(1)]
        [Name("NDB_number")]
        [Ignore]
        public string NdbNumber { get; set; }
    }
}