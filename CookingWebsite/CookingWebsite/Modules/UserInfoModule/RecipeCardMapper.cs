using CookingWebsite.Domain.Entities.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.UserInfoModule
{
    public static class RecipeCardMapper
    {
        public static RecipeCardDto Map(
            this Recipe recipe,
            List<RecipeLike> userLikes,
            List<RecipeFavourite> userFavourites,
            int userId,
            List<RecipeLike> recipeLikes,
            List<RecipeFavourite> recipeFavourites)
        {
            var recipeCard = new RecipeCardDto();

            recipeCard.Title = recipe.Title;
            recipeCard.Description = recipe.Description;
            recipeCard.AuthorUsername = recipe.AuthorUsername;
            recipeCard.CookingTime = recipe.CookingTime;
            recipeCard.Id = recipe.Id;
            recipeCard.ImageUrl = recipe.ImageUrl;
            recipeCard.PersonsCount = recipe.PersonsCount;

            recipeCard.LikesCount = recipeLikes.Count;

            recipeCard.FavouritesCount = recipeFavourites.Count;

            recipeCard.Tags = new List<string>();
            foreach (RecipeTag tag in recipe.Tags)
            {
                recipeCard.Tags.Add(tag.TagName);
            }

            recipeCard.IsLiked = userLikes.Any(r => r.UserId == userId && r.RecipeId == recipe.Id);

            recipeCard.IsFavourite = userFavourites.Any(r => r.UserId == userId && r.RecipeId == recipe.Id);

            return recipeCard;
        }
    }
}
