using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeFavouritesModule
{
    public static class RecipeFavouritesBindings
    {
        public static IServiceCollection AddRecipeFavouritesModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
