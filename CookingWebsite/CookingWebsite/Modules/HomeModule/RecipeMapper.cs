using CookingWebsite.Domain.Entities.Recipes;


namespace CookingWebsite.Modules.HomeModule
{
    public static class RecipeMapper
    {
        
        public static RecipeOfDayDto Map( this Recipe recipe )
        {
            if (recipe == null)
                return null;

            var recipeOfDay = new RecipeOfDayDto();

            recipeOfDay.Title = recipe.Title;
            recipeOfDay.Description = recipe.Description;
            recipeOfDay.AuthorUsername = recipe.AuthorUsername;
            recipeOfDay.Image = recipe.ImageUrl;
            recipeOfDay.LikesCount = recipe.LikesCount;
            recipeOfDay.CookingTime = recipe.CookingTime;

            return recipeOfDay;
        }   
    }
}
