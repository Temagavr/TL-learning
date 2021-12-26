using Microsoft.Extensions.DependencyInjection;

namespace CookingWebsite.Modules.RecipeUpdateModule
{
    public static class RecipeUpdateBindings
    {
        public static IServiceCollection AddRecipeUpdateModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
