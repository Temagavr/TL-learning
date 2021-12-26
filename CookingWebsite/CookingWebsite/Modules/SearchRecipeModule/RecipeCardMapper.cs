using CookingWebsite.Domain.Entities.Recipes;
using System.Collections.Generic;
using System.Linq;

namespace CookingWebsite.Modules.SearchRecipeModule
{
    public static class RecipeCardMapper
    {
        public static List<RecipeCardDto> Map(this List<Recipe> recipes, List<RecipeLike> recipeLikes, int userId)
        {
            var recipeCardsList = new List<RecipeCardDto>();

            foreach (Recipe recipe in recipes)
            {
                var recipeCard = new RecipeCardDto();

                recipeCard.Title = recipe.Title;
                recipeCard.Description = recipe.Description;
                recipeCard.AuthorUsername = recipe.AuthorUsername;
                recipeCard.CookingTime = recipe.CookingTime;
                recipeCard.FavouritesCount = recipe.FavouritesCount;
                recipeCard.Id = recipe.Id;
                recipeCard.ImageUrl = recipe.ImageUrl;
                recipeCard.LikesCount = recipe.LikesCount;
                recipeCard.PersonsCount = recipe.PersonsCount;

                recipeCard.Tags = new List<string>();
                foreach(RecipeTag tag in recipe.Tags)
                {
                    recipeCard.Tags.Add(tag.TagName);
                }

                var likeRecipe = recipeLikes.Where(r => r.UserId == userId && r.RecipeId == recipe.Id).ToList();

                if (likeRecipe.Count > 0)
                    recipeCard.IsLiked = true;
                else
                    recipeCard.IsLiked = false;

                recipeCardsList.Add(recipeCard);
            }

            return recipeCardsList;
        }
    }
}
