using System.Collections.Generic;
using System.Threading.Tasks;

namespace NuRecipesClient.Services.Recipes
{
    public interface IRecipesClient {
        Task PublishRecipeEvent();

    }
}