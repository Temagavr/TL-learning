using CookingWebsite.Domain.Entities.Recipes;


namespace CookingWebsite.Modules.HomeModule
{
    public static class RecipeMapper
    {
        
        public static RecipeOfDayDto Map( this Recipe recipe )
        {
            var recipeOfDay = new RecipeOfDayDto();

            recipeOfDay.Title = recipe.Title;
            recipeOfDay.Description = recipe.Description;
            recipeOfDay.AuthorUsername = recipe.AuthorUsername;
            recipeOfDay.ImageUrl = recipe.ImageUrl;
            recipeOfDay.LikesCount = recipe.LikesCount;
            recipeOfDay.CookingTime = recipe.CookingTime;

            return recipeOfDay;
        }   
    }
}
