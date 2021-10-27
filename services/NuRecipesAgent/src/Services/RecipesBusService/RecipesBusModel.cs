using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NuRecipesAgent.Models.Recipes
{
    public class RecipesBusMessage
    {
        public string type { get; set; }
        public string operation { get; set; }
        public Recipe recipe { get; set; }
    }
}