using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

using NuRecipesClient.Models.Foods;

namespace NuRecipesClient.Models.Recipes
{
    public class Recipe 
    {
        public string id { get; set; }
        public string type { get; set; }
        public RecipeDetails details { get; set; }
        public IList<RecipeDirections> directions { get; set; }
        public IList<RecipeSteps> steps { get; set; }
        public IList<RecipeFoods> foods { get; set; }
        public RecipeNutrition nutrition { get; set; }

    }

    public class RecipeDetails
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string cusine { get; set; }
        public string history { get; set; }
        public string region { get; set; }
        public string rating { get; set; }
        public string popularity { get; set; }

    }

    public class RecipeDirections
    {
        public string id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string rank { get; set; }

    }

    public class RecipeSteps
    {
        public string id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string rank { get; set; }
    }

    public class RecipeFoods
    {
        public FoodItem food { get; set; }
    }

    public class RecipeNutrition
    {

    }

    public class PagedRecipesList {
        public string ContinuationToken { get; set; }
        public IList<Recipe> RecipesList { get; set; }
    }

    public class RecipesList {
        public IList<Recipe> Recipes { get; set; }
    }
}

