using Microsoft.Extensions.DependencyInjection;

namespace CookingWebsite.Modules.RecipeModule
{
    public static class RecipeBindings
    {
        public static IServiceCollection AddRecipeModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
