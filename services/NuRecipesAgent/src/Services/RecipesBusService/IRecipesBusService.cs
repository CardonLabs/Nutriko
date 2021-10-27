using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using NuRecipesAgent.Models.Recipes;

namespace NuRecipesAgent.Services.Recipes
{
    public interface IRecipesBusService
    {
        IObservable<RecipesBusMessage> recipesObservable { get; }
        void PublishMessage(RecipesBusMessage msg);
        void AllItemsProcessed();
        
    }
}