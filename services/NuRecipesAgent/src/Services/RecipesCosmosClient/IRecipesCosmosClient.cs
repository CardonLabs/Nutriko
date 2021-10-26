using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Cosmos;

using NuRecipesAgent.Models.Recipes;

namespace NuRecipesAgent.Services.CosmosServiceClient
{
    public interface IRecipesCosmosClient
    {
        void Echo(string m);
        Task<ItemResponse<Recipe>> AddRecipeAsync(Recipe recipe);
        
    }
}