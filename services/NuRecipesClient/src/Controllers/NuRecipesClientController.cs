using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

using NuRecipesClient.Services.Recipes;
using NuRecipesClient.Services.RecipesServiceReader;
using NuRecipesClient.Models.Recipes;

namespace NuRecipesClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NuRecipesClientController : ControllerBase
    {

        private readonly ILogger<NuRecipesClientController> _logger;
        private IRecipesClient _recipesClient;
        private IRecipesReader _recipesReader;

        public NuRecipesClientController(ILogger<NuRecipesClientController> logger, IRecipesClient recipesClient, IRecipesReader recipesReader)
        {
            _logger = logger;
            _recipesClient = recipesClient;
            _recipesReader = recipesReader;
        }

        [HttpGet("test")]
        public string Get()
        {
            _recipesClient.GetRecipeAsync("2f26d86c-8168-47bf-a303-5cb6d0aafeba");
            return "hello";
        }

        [HttpPost("api/recipes/post")]
        public async Task<IActionResult> PostRecipe(Recipe recipePayload)
        {
            string eventType = "nutriko/type/recipe";
            string eventOperation = "nutriko/operation/post";

            var publishEvent = _recipesClient.PublishRecipeEvent(recipePayload, eventType, eventOperation);

            return new OkObjectResult(JsonSerializer.Serialize(publishEvent));
        }

        [HttpPut("api/recipes/update")]
        public async Task<IActionResult> UpsertRecipe(Recipe recipePayload)
        {
            string eventType = "nutriko/type/recipe";
            string eventOperation = "nutriko/operation/upsert";

            var publishEvent = _recipesClient.PublishRecipeEvent(recipePayload, eventType, eventOperation);

            return new OkObjectResult(JsonSerializer.Serialize(publishEvent));
        }

        [HttpDelete("api/recipes/delete")]
        public async Task<IActionResult> DeleteRecipe(Recipe recipePayload)
        {
            string eventType = "nutriko/type/recipe";
            string eventOperation = "nutriko/operation/delete";

            var publishEvent = _recipesClient.PublishRecipeEvent(recipePayload, eventType, eventOperation);

            return new OkObjectResult(JsonSerializer.Serialize(publishEvent));
        }

        [HttpGet("api/recipes/get")]
        public async Task<IActionResult> GetRecipe(Recipe recipePayload)
        {
            string eventType = "nutriko/type/recipe";
            string eventOperation = "nutriko/operation/read";

            var publishEvent = _recipesClient.PublishRecipeEvent(recipePayload, eventType, eventOperation);

            return new OkObjectResult(JsonSerializer.Serialize(publishEvent));
        }
    }
}
