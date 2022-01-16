using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.UserInfoModule
{
    public static class UserInfoMapper
    {
        public static UserInfoDto Map(
            this User user,
            List<RecipeLike> userLikes,
            List<RecipeFavourite> userFavourites,
            List<Recipe> recipes)
        {
            var userInfo = new UserInfoDto();

            userInfo.Login = user.Login;
            userInfo.Name = user.Name;
            userInfo.Description = user.Description;

            userInfo.LikesCount = userLikes.Count;
            userInfo.FavouritesCount = userFavourites.Count;
            userInfo.RecipesCount = recipes.Count;

            return userInfo;
        }
    }
}
