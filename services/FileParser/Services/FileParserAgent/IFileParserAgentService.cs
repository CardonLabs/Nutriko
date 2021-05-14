using System.Collections.Generic;
using System.Threading.Tasks;

using FileParser.Models.FdcShemas.SrLegacy;

namespace FileParser.Services.FileParserAgentService
{
    public interface IFileParserAgentService {
        Task ReadBlob ();
    }
}