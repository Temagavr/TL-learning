using CookingWebsite.Domain.Entities.Recipes;
using System.Collections.Generic;

namespace CookingWebsite.Modules.HomeModule
{
    public static class RecipeMapper
    {
        
        public static RecipeOfDayDto Map( this Recipe recipe, List<RecipeLike> recipeLikes )
        {
            if (recipe == null)
                return null;

            var recipeOfDay = new RecipeOfDayDto();

            recipeOfDay.Title = recipe.Title;
            recipeOfDay.Description = recipe.Description;
            recipeOfDay.AuthorUsername = recipe.AuthorUsername;
            recipeOfDay.Image = recipe.ImageUrl;
            recipeOfDay.LikesCount = recipeLikes.Count;
            recipeOfDay.CookingTime = recipe.CookingTime;

            return recipeOfDay;
        }   
    }
}
