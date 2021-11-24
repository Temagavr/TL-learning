using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CookingWebsite.Modules.HomeModule
{
    public static class HomeBindings
    {
        public static IServiceCollection AddHomeModule( this IServiceCollection services )
        {
            return services;
        }
    }
}
