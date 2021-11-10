using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Cosmos;

using NuRecipesClient.Models.Recipes;

namespace NuRecipesClient.Services.RecipesServiceReader
{
    public interface IRecipesReader
    {
        Task<ItemResponse<Recipe>> GetRecipeAsync(string id);
        
    }
}