
using System;
using System.Collections.Generic;

namespace FdcAgent.Services.BlobParserService
{
    public class FdcAgentBlobConfig {
        public string connectionString { get; set; }
        public string container { get; set; }
        public string blob { get; set; }
    }

    public class FdcAgentParserStatus {
        public int count { get; set; }
        public string message { get; set; }
    }
}