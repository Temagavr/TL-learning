using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.UserInfoModule
{
    public class UserInfoDto
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Description { get; set; }
        public int RecipesCount { get; set; }
        public int LikesCount { get; set; }
        public int FavouritesCount { get; set; }

    }
}
