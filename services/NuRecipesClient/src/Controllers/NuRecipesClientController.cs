using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NuRecipesClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NuRecipesClientController : ControllerBase
    {

        private readonly ILogger<NuRecipesClientController> _logger;

        public NuRecipesClientController(ILogger<NuRecipesClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet("test")]
        public string Get()
        {
            return "hello";
        }
    }
}
