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
            var imageSaveResult = await _fileService.SaveImgAsync(addRecipeDto.Image);

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
                likesCount: 0,
                favouritesCount: 0,
                authorUsername: "TestUser",
                ingredients,
                steps
            );

            _recipeRepostitory.Add(recipe);

            return;
        }
    }
}
