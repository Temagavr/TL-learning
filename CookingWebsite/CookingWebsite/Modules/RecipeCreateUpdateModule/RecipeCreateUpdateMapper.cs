using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeCreateUpdateModule
{
    public static class RecipeCreateUpdateMapper
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

            result.Ingredients = recipe.Ingredients.Select(x => new Application.Recipes.RecipeDtos.RecipeIngredientDto
            {
                Title = x.Title,
                Items = x.Items.Select(y => new Application.Recipes.RecipeDtos.RecipeIngredientItemDto
                {
                    Name = y.Name,
                    Value = y.Value
                }).ToList()
            }).ToList();

            result.Steps = recipe.Steps.Select((s, i) => new Application.Recipes.RecipeDtos.RecipeStepDto
            {
                StepNumber = i + 1,
                Description = s.Description
            }).ToList();

            result.Tags = recipe.Tags.Select(x => new Application.Recipes.RecipeDtos.RecipeTagDto
            {
                TagName = x
            }).ToList();

            result.AuthorUsername = authorizedUser;

            result.Image = await FileManagment.CreateAsync(files[0]);

            return result;
        }

        public async static Task<Application.Recipes.RecipeDtos.UpdateRecipeDto> Map
        (
            this UpdateRecipeDto recipe,
            IFormFileCollection files
        )
        {
            var result = new Application.Recipes.RecipeDtos.UpdateRecipeDto();

            result.Id = recipe.Id;
            result.Title = recipe.Title;
            result.Description = recipe.Description;
            result.CookingTime = recipe.CookingTime;
            result.PersonsCount = recipe.PersonsCount;

            result.Ingredients = recipe.Ingredients.Select(x => new Application.Recipes.RecipeDtos.RecipeIngredientDto
            {
                Title = x.Title,
                Items = x.Items.Select(y => new Application.Recipes.RecipeDtos.RecipeIngredientItemDto
                {
                    Name = y.Name,
                    Value = y.Value
                }).ToList()
            }).ToList();

            result.Steps = recipe.Steps.Select((s, i) => new Application.Recipes.RecipeDtos.RecipeStepDto
            {
                StepNumber = i + 1,
                Description = s.Description
            }).ToList();

            result.Tags = new List<Application.Recipes.RecipeDtos.RecipeTagDto>();

            if (recipe.Tags.Count > 0)
            {
                result.Tags = recipe.Tags.Select(x => new Application.Recipes.RecipeDtos.RecipeTagDto
                {
                    TagName = x
                }).ToList();
            }

            if (files.Count > 0)
                result.Image = await FileManagment.CreateAsync(files[0]);
            else
                result.Image = null;

            return result;
        }
    }
}
