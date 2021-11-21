using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Entities.Users
{
    public class UserStatistic
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int RecipesCount { get; private set; }
        public int LikesCount { get; private set; }
        public int FavouritesCount { get; private set; }

        public UserStatistic(
            int userId,
            int recipesCount, 
            int likesCount,
            int favouritesCount
            )
        {
            UserId = userId;
            RecipesCount = recipesCount;
            LikesCount = likesCount;
            FavouritesCount = favouritesCount;
        }

        protected UserStatistic() { }
    }
}
