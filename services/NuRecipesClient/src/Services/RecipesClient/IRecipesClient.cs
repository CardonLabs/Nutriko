using System.Collections.Generic;
using System.Threading.Tasks;

using NuRecipesClient.Models.Recipes;

namespace NuRecipesClient.Services.Recipes
{
    public interface IRecipesClient {
        Task PublishRecipeEvent(Recipe recipe, string eventType, string eventOperation);

    }
}