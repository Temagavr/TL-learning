using CookingWebsite.Application.Account;
using CookingWebsite.Application.Recipes;
using Microsoft.Extensions.DependencyInjection;

namespace CookingWebsite.Application
{
    public static class ApplicationBindings
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRecipeService, RecipeService>();

            return services;
        }
    }
}
