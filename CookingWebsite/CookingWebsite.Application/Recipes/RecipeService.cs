using CookingWebsite.Application.Files;
using CookingWebsite.Application.Recipes.RecipeDtos;
using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static CookingWebsite.Application.Files.FileService;

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
            var imageSaveResult = await _fileService.SaveAsync(addRecipeDto.Image, "\\recipes");

            List<RecipeIngredient> ingredients = addRecipeDto.Ingredients.Select(x => new RecipeIngredient(
                    x.Title,
                    x.Items.Select(y => new RecipeIngredientItem(
                        y.Name,
                        y.Value
                    )).ToList()
            )).ToList();

            List<RecipeStep> steps = addRecipeDto.Steps.Select(x => new RecipeStep
            (
                x.StepNumber,
                x.Description
            )).ToList();

            var recipe = new Recipe(
                imageSaveResult.RelativePath,
                addRecipeDto.Title,
                addRecipeDto.Description,
                addRecipeDto.CookingTime,
                addRecipeDto.PersonsCount,
                authorUsername: "TestUser",
                ingredients,
                steps
            );

            _recipeRepostitory.Add(recipe);

            return;
        }

        public async Task UpdateRecipe(UpdateRecipeDto updateRecipeDto)
        {
            var recipe = await _recipeRepostitory.GetById(updateRecipeDto.Id);

            FileSaveResult imageSaveResult = new FileSaveResult();
            if (updateRecipeDto.Image != null)
                imageSaveResult = await _fileService.SaveAsync(updateRecipeDto.Image, "\\recipes");
            else
                imageSaveResult.RelativePath = recipe.ImageUrl;

            List<RecipeIngredient> ingredients = updateRecipeDto.Ingredients.Select(x => new RecipeIngredient(
                    x.Title,
                    x.Items.Select(y => new RecipeIngredientItem(
                        y.Name,
                        y.Value
                    )).ToList()
            )).ToList();

            List<RecipeStep> steps = updateRecipeDto.Steps.Select(x => new RecipeStep
            (
                x.StepNumber,
                x.Description
            )).ToList();

            recipe.Update(
                imageSaveResult.RelativePath,
                updateRecipeDto.Title,
                updateRecipeDto.Description,
                updateRecipeDto.CookingTime,
                updateRecipeDto.PersonsCount,
                authorUsername: "TestUserName",
                ingredients,
                steps
            );
        }
    }
}
