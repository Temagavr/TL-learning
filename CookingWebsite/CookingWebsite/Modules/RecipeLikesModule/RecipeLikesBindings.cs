using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeLikesModule
{
    public static class RecipeLikesBindings
    {
        public static IServiceCollection AddRecipeLikesModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
