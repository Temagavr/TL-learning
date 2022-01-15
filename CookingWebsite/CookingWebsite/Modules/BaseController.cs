using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookingWebsite.Modules
{
    public class BaseController : ControllerBase
    {
        public int GetAuthorizedUserId()
        {
            return Convert.ToInt32(User.FindFirstValue(Claims.UserId));
        }

        public string GetAuthorizedUserUsername()
        {
            return User.FindFirstValue(Claims.Username);
        }

        public void ChangeAuthorizedUserName(string newName)
        {

        }

    }
}
