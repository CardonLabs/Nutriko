using System.Collections.Generic;
using System.Threading.Tasks;


namespace FdcAgent.Services.BlobParserService
{
    public interface IFdcAgentBlobParser {
        Task<string> ReadBlob ();
    }
}