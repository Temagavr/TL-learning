﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeUpdateModule
{
    public static class UpdateRecipeMapper
    {
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

            if (files.Count > 0)
                result.Image = await FileManagment.CreateAsync(files[0]);
            else
                result.Image = null;

            return result;
        }
    }
}
