using CookingWebsite.Domain.Entities.Recipes;

namespace CookingWebsite.Modules.RecipeModule
{
    public static class RecipeMapper
    {
        public static RecipeDetailsDto Map( this Recipe recipe)
        {
            var recipeDetailsDto = new RecipeDetailsDto();

            recipeDetailsDto.Title = recipe.Title;
            recipeDetailsDto.Description = recipe.Description;
            recipeDetailsDto.AuthorUsername = recipe.AuthorUsername;
            recipeDetailsDto.CookingTime = recipe.CookingTime;
            recipeDetailsDto.FavouritesCount = recipe.FavouritesCount;
            recipeDetailsDto.Id = recipe.Id;
            recipeDetailsDto.ImageUrl = recipe.ImageUrl;
            recipeDetailsDto.LikesCount = recipe.LikesCount;
            recipeDetailsDto.PersonsCount = recipe.PersonsCount;

            foreach (RecipeIngredient ingredient in recipe.Ingredients)
            {
                var recipeIngredientDto = new RecipeIngredientDto();

                recipeIngredientDto.Title = ingredient.Title;
                recipeIngredientDto.RecipeId = ingredient.RecipeId;

                foreach (RecipeIngredientItem item in ingredient.Items)
                {
                    var ingredientItemDto = new RecipeIngredientItemDto();
                    ingredientItemDto.RecipeIngredientId = item.RecipeIngredientId;
                    ingredientItemDto.Name = item.Name;
                    ingredientItemDto.Value = item.Value;

                    recipeIngredientDto.Items.Add(ingredientItemDto);
                }
            }

            recipe.Steps.Sort((s1, s2) => s1.StepNumber <= s2.StepNumber ? -1 : 1);

            foreach (RecipeStep step in recipe.Steps)
            {
                var stepDto = new RecipeStepDto();

                stepDto.RecipeId = step.RecipeId;
                stepDto.StepNumber = step.StepNumber;
                stepDto.Description = step.Description;

                recipeDetailsDto.Steps.Add(stepDto);
            }

            return recipeDetailsDto;
        }
    }
}
