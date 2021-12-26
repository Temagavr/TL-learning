using Microsoft.Extensions.DependencyInjection;

namespace CookingWebsite.Modules.RecipeCreateModule
{
    public static class RecipeCreateBindings
    {
        public static IServiceCollection AddRecipeCreateModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
