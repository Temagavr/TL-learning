using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.SearchRecipeModule
{
    public static class SearchRecipeBindings
    {
        public static IServiceCollection AddRecipeSearchModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
