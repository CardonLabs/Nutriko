
using System;
using System.Collections.Generic;

namespace FileParser.Models.FileParserAgentService 
{
    public class BlobStorageConfig {
        public string connectionString { get; set; }
        public string container { get; set; }
        public string blob { get; set; }
    }
}