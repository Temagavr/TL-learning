using CookingWebsite.Domain.Entities.Recipes;
using System.Collections.Generic;

namespace CookingWebsite.Modules.SearchRecipeModule
{
    public static class RecipeCardMapper
    {
        public static List<RecipeCardDto> Map(this List<Recipe> recipes)
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

                recipeCardsList.Add(recipeCard);
            }

            return recipeCardsList;
        }
    }
}
