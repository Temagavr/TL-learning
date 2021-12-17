using CookingWebsite.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.AccountModule
{
    public static class UserInfoMapper
    {
        public static UserInfoDto Map(this User user)
        {
            var userInfo = new UserInfoDto();

            userInfo.Id = user.Id;
            userInfo.Login = user.Login;
            userInfo.Description = user.Description;
            userInfo.Name = user.Name;
            userInfo.Password = user.Password;

            return userInfo;
        }
    }
}
