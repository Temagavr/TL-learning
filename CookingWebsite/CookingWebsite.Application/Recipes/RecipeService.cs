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

        private const string ImagesPath = @"E:\TL-learning\CookingWebsite\CookingWebsite\ClientApp\src\assets\recipes";

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepostitory = recipeRepository;
        }

        public async Task<Recipe> GetRecipeOfDay()
        {
            var recipeOfDay = await _recipeRepostitory.GetFirst();

            return recipeOfDay;
        }
        
        public async Task AddRecipe(AddRecipeDto addRecipeDto)
        {
            Directory.CreateDirectory(ImagesPath);
            var imageSaveResult = await SaveAsync(addRecipeDto.Image, ImagesPath);

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

        private async Task<FileSaveResult> SaveAsync(FileService formFile, string basePath)
        {
            string fileName = $"{Guid.NewGuid().ToString()}.{formFile.FileExtension}";
            var newFilePath = $@"{basePath}\{fileName}";
            using (FileStream fs = File.Create(newFilePath))
            {
                await fs.WriteAsync(formFile.Data);
            }

            string folderName = basePath.Split(@"\").Last();
            return new FileSaveResult
            {
                RelativePath = $@"{folderName}/{fileName}"
            };
        }

        private class FileSaveResult
        {
            public string RelativePath { get; set; }
        }

    }
}
