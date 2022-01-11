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
        private readonly IRecipeFavouriteRepository _recipeFavouriteRepository;
        private readonly IFileService _fileService;

        public RecipeService(
            IRecipeRepository recipeRepository,
            IRecipeLikeRepository recipeLikeRepository,
            IRecipeFavouriteRepository recipeFavouriteRepository,
            IFileService fileService)
        {
            _recipeRepository = recipeRepository;
            _recipeLikeRepository = recipeLikeRepository;
            _recipeFavouriteRepository = recipeFavouriteRepository;
            _fileService = fileService;
        }

        public async Task<Recipe> GetRecipeOfDay()
        {
            var recipeOfDay = await _recipeRepository.GetFirst();
            
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

        public async Task AddLike(int recipeId, int userId)
        {
            var like = await _recipeLikeRepository.GetByUserIdAndRecipeId(userId, recipeId);

            if (like == null)
            {
                var recipeLike = new RecipeLike(userId, recipeId);

                _recipeLikeRepository.Add(recipeLike);
            }
        }

        public async Task RemoveLike(int userId, int recipeId)
        {
            var recipeLike = await _recipeLikeRepository.GetByUserIdAndRecipeId(userId, recipeId);

            _recipeLikeRepository.Remove(recipeLike);
        }

        public async Task AddFavourite(int recipeId, int userId)
        {
            var favourite = await _recipeFavouriteRepository.GetByUserIdAndRecipeId(userId, recipeId);

            if (favourite == null)
            {
                var recipeFavourite = new RecipeFavourite(userId, recipeId);

                _recipeFavouriteRepository.Add(recipeFavourite);
            }
        }

        public async Task RemoveFavourite(int userId, int recipeId)
        {
            var recipeFavourite = await _recipeFavouriteRepository.GetByUserIdAndRecipeId(userId, recipeId);

            _recipeFavouriteRepository.Remove(recipeFavourite);
        }

        public async Task<List<Recipe>> GetUserFavourites(int skip, int take, int userId)
        {
            List<RecipeFavourite> recipeFavourites = await _recipeFavouriteRepository.GetUserFavourites(skip, take, userId);
            
            if(recipeFavourites != null)
            {
                var recipes = new List<Recipe>();

                foreach(RecipeFavourite favourite in recipeFavourites)
                {
                    recipes.Add(await _recipeRepository.GetById(favourite.RecipeId));
                }

                return recipes;
            }

            return new List<Recipe>();
        }
    }
}
