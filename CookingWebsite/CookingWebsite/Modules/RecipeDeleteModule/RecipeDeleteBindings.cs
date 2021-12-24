using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeDeleteModule
{
    public static class RecipeDeleteBindings
    {
        public static IServiceCollection AddRecipeDeleteModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
