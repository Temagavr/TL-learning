using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.UserInfoModule
{
    public static class UserInfoBindings
    {
        public static IServiceCollection AddUserInfoModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
