using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Cosmos;


using NuRecipesClient.Models.Recipes;

namespace NuRecipesClient.Services.RecipesServiceReader
{
    public interface IRecipesReader
    {
        Task<RecipesClientResponse> GetRecipeAsync(string id);
        Task<PaginatedRecipesClientResponse<Recipe>> GetPaginatedRecipesAsync(string continuationToken);
    }
}