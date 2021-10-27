using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

using NuRecipesClient.Services.Recipes;
using NuRecipesClient.Models.Recipes;

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
            return "hello";
        }

        [HttpPost("api/recipe")]
        public async Task<IActionResult> PostRecipe(Recipe recipePayload)
        {
            string eventType = "nutriko/type/recipe";
            string eventOperation = "nutriko/operation/post";

            var publishEvent = _recipesClient.PublishRecipeEvent(recipePayload, eventType, eventOperation);

            return new OkObjectResult(JsonSerializer.Serialize(publishEvent));
        }
    }
}
