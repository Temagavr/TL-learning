using CookingWebsite.Domain.Entities.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.HomeModule
{
    public static class RecipeMapper
    {
        
        public static RecipeOfDayDto Map( this Recipe recipe )
        {
            var recipeOfDay = new RecipeOfDayDto();

            recipeOfDay.Title = recipe.Title;
            recipeOfDay.Description = recipe.Description;
            recipeOfDay.AuthorUsername = recipeOfDay.AuthorUsername;
            recipeOfDay.ImageUrl = recipe.ImageUrl;
            recipeOfDay.LikesCount = recipe.LikesCount;
            recipeOfDay.FavouritesCount = recipe.FavouritesCount;
            recipeOfDay.PersonsCount = recipe.PersonsCount;
            recipeOfDay.CookingTime = recipe.CookingTime;

            return recipeOfDay;
        }
        
    }
}
