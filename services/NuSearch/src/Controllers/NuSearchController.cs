using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NuSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NuSearchController : ControllerBase
    {
        private readonly ILogger<NuSearchController> _logger;

        public NuSearchController(ILogger<NuSearchController> logger)
        {
            _logger = logger;
        }

    }
}
