using Microsoft.Extensions.DependencyInjection;

namespace CookingWebsite.Modules.AccountModule
{
    public static class AccoutBindings
    {
        public static IServiceCollection AddAccountModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
