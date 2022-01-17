using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;

using NuRecipesClient.Models.Recipes;

namespace NuRecipesClient.Models.Recipes
{
    public class RecipesClientResponse
    {
        public HttpStatusCode status { get; set; }
        public string message { get; set; }
        public Recipe recipe { get; set; }
    }

    public class PaginatedRecipesClientResponse<T>
    {
        public HttpStatusCode status { get; set; }
        public string message { get; set; }
        public string continuationToken { get; set; }
        public IList<T> recipe { get; set; }
    }

    public class RecipeItem
    {
        public string id { get; set; }
    }

    public class ContinuationToken
    {
        public string Version { get; set; }
        public string QueryPlan { get; set; }
        public string SourceContinuationToken { get; set; }
    }

    public class RecipeContinuationToken
    {
        public string ContinuationToken { get; set; }
    }
}