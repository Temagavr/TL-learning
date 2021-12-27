using Microsoft.Extensions.DependencyInjection;

namespace CookingWebsite.Modules.RecipeCreateUpdateModule
{
    public static class RecipeCreateUpdateBindings
    {
        public static IServiceCollection AddRecipeCreateUpdateModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
