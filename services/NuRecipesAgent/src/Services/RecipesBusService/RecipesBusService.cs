using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reactive;
using System.Reactive.Subjects;
using System.Reactive.Linq;

using NuRecipesAgent.Models.Recipes;

namespace NuRecipesAgent.Services.Recipes
{
    public static class RecipesBusServiceExtension
    {
        public static void AddRecipesBusService(this IServiceCollection services)
        {
            services.AddSingleton<IRecipesBusService>( (container) => {
                var logger = container.GetRequiredService<ILogger<RecipesBusService>>();

                return InitializeRecipesBusService(logger).GetAwaiter().GetResult();

            });
        }

        public static async Task<RecipesBusService> InitializeRecipesBusService(ILogger<RecipesBusService> logger)
        {
            Subject<RecipesBusMessage> subject = new Subject<RecipesBusMessage>();
            RecipesBusService recipesBusService = new RecipesBusService(logger, subject);

            return recipesBusService;

        }
    }

    public class RecipesBusService : IRecipesBusService
    {
        private ILogger<RecipesBusService> _logger;
        private Subject<RecipesBusMessage> _recipesBusMessage;
        public IObservable<RecipesBusMessage> recipesObservable {get;}

        public RecipesBusService(ILogger<RecipesBusService> logger, Subject<RecipesBusMessage> subject)
        {
            _logger = logger;
            _recipesBusMessage = subject;
            recipesObservable = subject.AsObservable();
            
        }

        public void AllItemsProcessed() 
        {
            _recipesBusMessage.OnCompleted();
        }

        public void PublishMessage(RecipesBusMessage message)
        {
            try
            {
                _recipesBusMessage.OnNext(message);
            }
            catch (Exception e)
            {
                _recipesBusMessage.OnError(e);
            }

        }
    }
}