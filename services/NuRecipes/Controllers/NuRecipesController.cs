using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NuRecipes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NuRecipesController : ControllerBase
    {

        private readonly ILogger<NuRecipesController> _logger;

        public NuRecipesController(ILogger<NuRecipesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {

        }
    }
}
