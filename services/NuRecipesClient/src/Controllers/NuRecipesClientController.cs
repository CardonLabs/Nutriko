using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using NuRecipesClient.Services.Recipes;

namespace NuRecipesClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NuRecipesClientController : ControllerBase
    {

        private readonly ILogger<NuRecipesClientController> _logger;
        private IRecipesClient _recipesClient;

        public NuRecipesClientController(ILogger<NuRecipesClientController> logger, IRecipesClient recipesClient)
        {
            _logger = logger;
            _recipesClient = recipesClient;
        }

        [HttpGet("test")]
        public string Get()
        {
            _recipesClient.PublishRecipeEvent();
            return "hello";
        }
    }
}
