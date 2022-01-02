using CookingWebsite.Domain;
using CookingWebsite.Domain.Repositories;
using CookingWebsite.Infrastructure.Foundation;
using CookingWebsite.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CookingWebsite.Infrastructure
{
    public static class InfrastructureBindings
    {
        public static IServiceCollection AddRepositories( this IServiceCollection services )
        {
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserStatisticRepository, UserStatisticRepository>();
            services.AddScoped<IRecipeLikeRepository, RecipeLikeRepository>();
            services.AddScoped<IRecipeFavouriteRepository, RecipeFavouriteRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
