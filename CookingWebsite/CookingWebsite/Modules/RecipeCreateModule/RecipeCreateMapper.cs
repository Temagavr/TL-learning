using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeCreateModule
{
    public static class RecipeCreateMapper
    {
        public async static Task<Application.Recipes.RecipeDtos.AddRecipeDto> Map(
            this AddRecipeDto recipe,
            IFormFileCollection files,
            string authorizedUser)
        {
            var result = new Application.Recipes.RecipeDtos.AddRecipeDto();

            result.Title = recipe.Title;
            result.Description = recipe.Description;
            result.CookingTime = recipe.CookingTime;
            result.PersonsCount = recipe.PersonsCount;

            result.Ingredients = new List<Application.Recipes.RecipeDtos.RecipeIngredientDto>();

            result.Ingredients = recipe.Ingredients.Select(x => new Application.Recipes.RecipeDtos.RecipeIngredientDto
            {
                Title = x.Title,
                Items = x.Items.Select(y => new Application.Recipes.RecipeDtos.RecipeIngredientItemDto
                {
                    Name = y.Name,
                    Value = y.Value
                }).ToList()
            }).ToList();

            result.Steps = new List<Application.Recipes.RecipeDtos.RecipeStepDto>();

            result.Steps = recipe.Steps.Select((s, i) => new Application.Recipes.RecipeDtos.RecipeStepDto
            {
                StepNumber = i + 1,
                Description = s.Description
            }).ToList();

            result.AuthorUsername = authorizedUser;

            result.Image = await FileManagment.CreateAsync(files[0]);

            return result;
        }
    }
}
