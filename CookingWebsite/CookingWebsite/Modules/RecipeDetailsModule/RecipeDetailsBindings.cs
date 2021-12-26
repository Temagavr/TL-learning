using Microsoft.Extensions.DependencyInjection;

namespace CookingWebsite.Modules.RecipeDetailsModule
{
    public static class RecipeDetailsBindings
    {
        public static IServiceCollection AddRecipeDetailsModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
