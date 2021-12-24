using Microsoft.Extensions.DependencyInjection;

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
