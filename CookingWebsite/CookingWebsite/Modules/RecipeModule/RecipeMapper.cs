using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Modules.RecipeModule.Dtos;
using System.Collections.Generic;
using System.Linq;

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

            recipeDetailsDto.Ingredients = new List<RecipeIngredientDto>();
            recipeDetailsDto.Steps = new List<string>();

            recipeDetailsDto.Ingredients = recipe.Ingredients.Select(x => new RecipeIngredientDto
            {
                RecipeId = x.RecipeId,
                Title = x.Title,
                Items = x.Items.Select(y => new RecipeIngredientItemDto
                {
                    RecipeIngredientId = y.RecipeIngredientId,
                    Name = y.Name,
                    Value = y.Value
                }).ToList()
            }).ToList();

            recipe.Steps.Sort((s1, s2) => s1.StepNumber <= s2.StepNumber ? -1 : 1);

            foreach (RecipeStep step in recipe.Steps)
            {
                recipeDetailsDto.Steps.Add(step.Description);
            }

            return recipeDetailsDto;
        }

        public static List<RecipeCardDto> Map(this List<Recipe> recipes)
        {
            var recipeCardsList = new List<RecipeCardDto>();

            foreach( Recipe recipe in recipes)
            {
                var recipeCard = new RecipeCardDto();

                recipeCard.Title = recipe.Title;
                recipeCard.Description = recipe.Description;
                recipeCard.AuthorUsername = recipe.AuthorUsername;
                recipeCard.CookingTime = recipe.CookingTime;
                recipeCard.FavouritesCount = recipe.FavouritesCount;
                recipeCard.Id = recipe.Id;
                recipeCard.ImageUrl = recipe.ImageUrl;
                recipeCard.LikesCount = recipe.LikesCount;
                recipeCard.PersonsCount = recipe.PersonsCount;

                recipeCardsList.Add(recipeCard);
            }

            return recipeCardsList;
        }

        public static Application.Recipes.RecipeDtos.AddRecipeDto Map(this AddRecipeDto recipe)
        {
            var result = new Application.Recipes.RecipeDtos.AddRecipeDto();

            result.Title = recipe.Title;
            result.Description = recipe.Description;
            result.AuthorUsername = recipe.AuthorUsername;
            result.CookingTime = recipe.CookingTime;
            result.PersonsCount = recipe.PersonsCount;

            result.Ingredients = new List<Application.Recipes.RecipeDtos.RecipeIngredientDto>();
            
            result.Ingredients = recipe.Ingredients.Select(x => new Application.Recipes.RecipeDtos.RecipeIngredientDto {
                Title = x.Title,
                Items = x.Items.Select( y => new Application.Recipes.RecipeDtos.RecipeIngredientItemDto {
                    Name = y.Name,
                    Value = y.Value
                }).ToList()
            }).ToList();

            result.Steps = new List<Application.Recipes.RecipeDtos.RecipeStepDto>();

            result.Steps = recipe.Steps.Select((s, i) => new Application.Recipes.RecipeDtos.RecipeStepDto {
                StepNum = i + 1,
                Description = s.Description
            }).ToList();

            return result;
        }
    }
}
