using Microsoft.Extensions.DependencyInjection;

namespace CookingWebsite.Modules.UserFavouritesModule
{
    public static class UserFavouritesBindings
    {
        public static IServiceCollection AddUserFavouritesModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
