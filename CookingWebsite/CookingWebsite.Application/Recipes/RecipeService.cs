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

        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeLikeRepository _recipeLikeRepository;
        private readonly IFileService _fileService;

        public RecipeService(
            IRecipeRepository recipeRepository,
            IRecipeLikeRepository recipeLikeRepository,
            IFileService fileService
            )
        {
            _recipeRepository = recipeRepository;
            _recipeLikeRepository = recipeLikeRepository;
            _fileService = fileService;
        }

        public async Task<Recipe> GetRecipeOfDay()
        {
            var recipeOfDay = await _recipeRepository.GetFirst();
            GetRecipeLikes(2);

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

            List<RecipeTag> tags = new List<RecipeTag>();

            if (addRecipeDto.Tags.Count > 0)
            {
                tags = addRecipeDto.Tags.Select(x => new RecipeTag(
                    x.TagName
                )).ToList();
            }

            var recipe = new Recipe(
                imageSaveResult.RelativePath,
                addRecipeDto.Title,
                addRecipeDto.Description,
                addRecipeDto.CookingTime,
                addRecipeDto.PersonsCount,
                addRecipeDto.AuthorUsername,
                ingredients,
                steps,
                tags
            );

            _recipeRepository.Add(recipe);

            GetRecipeLikes(2);
        }

        public async Task UpdateRecipe(UpdateRecipeDto updateRecipeDto)
        {
            var recipe = await _recipeRepository.GetById(updateRecipeDto.Id);

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

            List<RecipeTag> tags = new List<RecipeTag>();

            if (updateRecipeDto.Tags.Count > 0)
            {
                tags = updateRecipeDto.Tags.Select(x => new RecipeTag(
                    x.TagName
                )).ToList();
            }

            recipe.Update(
                imageSaveResult.RelativePath,
                updateRecipeDto.Title,
                updateRecipeDto.Description,
                updateRecipeDto.CookingTime,
                updateRecipeDto.PersonsCount,
                ingredients,
                steps,
                tags
            );
        }

        private async void GetRecipeLikes(int recipeId)
        {
            _recipeLikeRepository.AddLike(new RecipeLike(1, 2));
            _recipeLikeRepository.AddLike(new RecipeLike(2, 2));
            _recipeLikeRepository.AddLike(new RecipeLike(3, 2));

            var temp = await _recipeLikeRepository.GetRecipeLikesCount(recipeId);

            Console.WriteLine();
        }
    }
}
