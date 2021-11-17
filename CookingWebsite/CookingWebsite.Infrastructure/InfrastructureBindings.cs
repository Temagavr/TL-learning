using CookingWebsite.Domain.Repositories;
using CookingWebsite.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CookingWebsite.Infrastructure
{
    public static class InfrastructureBindings
    {
        public static IServiceCollection AddRepositories( this IServiceCollection services )
        {
            services.AddScoped<IRecipeRepository, RecipeRepository>();

            return services;
        }
    }
}
