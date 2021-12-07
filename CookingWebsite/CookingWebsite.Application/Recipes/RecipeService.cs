using CookingWebsite.Application.Files;
using CookingWebsite.Application.Recipes.RecipeDtos;
using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Recipes
{
    public class RecipeService : IRecipeService
    {

        private readonly IRecipeRepository _recipeRepostitory;
        private readonly IFileService _fileService;

        public RecipeService(IRecipeRepository recipeRepository, IFileService fileService)
        {
            _recipeRepostitory = recipeRepository;
            _fileService = fileService;
        }

        public async Task<Recipe> GetRecipeOfDay()
        {
            var recipeOfDay = await _recipeRepostitory.GetFirst();

            return recipeOfDay;
        }
        
        public async Task AddRecipe(AddRecipeDto addRecipeDto)
        {
            var imageSaveResult = await _fileService.SaveAsync(addRecipeDto.Image);

            var recipe = new Recipe(
                imageSaveResult.RelativePath,
                addRecipeDto.Title,
                addRecipeDto.Description,
                addRecipeDto.CookingTime,
                addRecipeDto.PersonsCount,
                likesCount: 0,
                favouritesCount: 0,
                authorUsername: "TestUser"
            );

            recipe.SetIngredients(new List<RecipeIngredient>());
            recipe.SetSteps(new List<RecipeStep>());

            //_recipeRepostitory.Add(recipe);

            foreach (RecipeIngredientDto ingredientDto in addRecipeDto.Ingredients)
            {
                RecipeIngredient recipeIngredient = new RecipeIngredient(
                    recipe.Id,
                    ingredientDto.Title
                );
                recipeIngredient.SetItems( new List<RecipeIngredientItem>() );
                //_recipeRepostitory.AddRecipeIngredient(recipeIngredient);

                foreach(RecipeIngredientItemDto ingredientItemDto in ingredientDto.Items)
                {
                    RecipeIngredientItem ingredientItem = new RecipeIngredientItem(
                        recipeIngredient.Id,
                        ingredientItemDto.Name,
                        ingredientItemDto.Value
                    );

                    recipeIngredient.Items.Add(ingredientItem);
                    //_recipeRepostitory.AddRecipeIngredientItem(ingredientItem);
                }

                recipe.Ingredients.Add(recipeIngredient);
            }

            foreach(RecipeStepDto stepDto in addRecipeDto.Steps)
            {
                RecipeStep step = new RecipeStep(
                    recipe.Id,
                    stepDto.StepNum,
                    stepDto.Description
                );

                recipe.Steps.Add(step);

                //_recipeRepostitory.AddRecipeStep(step);
            }

            _recipeRepostitory.Add(recipe);

            return;
        }
    }
}
