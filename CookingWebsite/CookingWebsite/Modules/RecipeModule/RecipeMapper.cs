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

            foreach (RecipeIngredient ingredient in recipe.Ingredients)
            {
                var recipeIngredientDto = new RecipeIngredientDto();

                recipeIngredientDto.Title = ingredient.Title;
                recipeIngredientDto.RecipeId = ingredient.RecipeId;
                recipeIngredientDto.Items = new List<RecipeIngredientItemDto>();
                /*
                recipeIngredientDto.Items = (List<RecipeIngredientItemDto>)(from item in ingredient.Items
                                            select new RecipeIngredientItemDto
                                            {
                                                Name = item.Name,
                                                Value = item.Value,
                                                RecipeIngredientId = item.RecipeIngredientId
                                            });
                */

                foreach (RecipeIngredientItem item in ingredient.Items)
                {
                    var ingredientItemDto = new RecipeIngredientItemDto();
                    ingredientItemDto.RecipeIngredientId = item.RecipeIngredientId;
                    ingredientItemDto.Name = item.Name;
                    ingredientItemDto.Value = item.Value;

                    recipeIngredientDto.Items.Add(ingredientItemDto);
                }

                recipeDetailsDto.Ingredients.Add(recipeIngredientDto);
            }

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
            var recipeDto = new Application.Recipes.RecipeDtos.AddRecipeDto();

            recipeDto.Title = recipe.Title;
            recipeDto.Description = recipe.Description;
            recipeDto.AuthorUsername = recipe.AuthorUsername;
            recipeDto.CookingTime = recipe.CookingTime;
            recipeDto.PersonsCount = recipe.PersonsCount;

            recipeDto.RecipeIngredient = new List<Application.Recipes.RecipeDtos.RecipeIngredientDto>();

            foreach (RecipeIngredientDto ingredient in recipe.RecipeIngredient)
            {
                var recipeIngredientDto = new Application.Recipes.RecipeDtos.RecipeIngredientDto();

                recipeIngredientDto.Title = ingredient.Title;
                recipeIngredientDto.Items = new List<Application.Recipes.RecipeDtos.RecipeIngredientItemDto>();


                foreach (RecipeIngredientItemDto item in ingredient.Items)
                {
                    var ingredientItemDto = new Application.Recipes.RecipeDtos.RecipeIngredientItemDto();
                    ingredientItemDto.Name = item.Name;
                    ingredientItemDto.Value = item.Value;

                    recipeIngredientDto.Items.Add(ingredientItemDto);
                }

                recipeDto.RecipeIngredient.Add(recipeIngredientDto);
            }

            recipeDto.Steps = new List<Application.Recipes.RecipeDtos.RecipeStepDto>();

            for (int stepIndex = 0; stepIndex < recipe.Steps.Count; stepIndex++ )
            {
                var stepDto = new Application.Recipes.RecipeDtos.RecipeStepDto();

                stepDto.StepNum = stepIndex + 1;
                stepDto.Description = recipe.Steps[stepIndex].Description;

                recipeDto.Steps.Add(stepDto);
            }

            return recipeDto;
        }
    }
}
