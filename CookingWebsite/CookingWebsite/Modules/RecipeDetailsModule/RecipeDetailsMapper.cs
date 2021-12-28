using CookingWebsite.Domain.Entities.Recipes;
using System.Collections.Generic;
using System.Linq;

namespace CookingWebsite.Modules.RecipeDetailsModule
{
    public static class RecipeDetailsMapper
    {
        public static RecipeDetailsDto Map(
            this Recipe recipe,
            string authorizedUser,
            List<RecipeLike> recipeLikes,
            int userId
            )
        {
            var recipeDetailsDto = new RecipeDetailsDto();

            recipeDetailsDto.Title = recipe.Title;
            recipeDetailsDto.Description = recipe.Description;
            recipeDetailsDto.AuthorUsername = recipe.AuthorUsername;
            recipeDetailsDto.CookingTime = recipe.CookingTime;
            recipeDetailsDto.FavouritesCount = 0;
            recipeDetailsDto.Id = recipe.Id;
            recipeDetailsDto.ImageUrl = recipe.ImageUrl;
            recipeDetailsDto.LikesCount = recipeLikes.Count;
            recipeDetailsDto.PersonsCount = recipe.PersonsCount;

            recipeDetailsDto.Ingredients = new List<RecipeIngredientDto>();
            recipeDetailsDto.Steps = new List<string>();
            recipeDetailsDto.Tags = new List<string>();

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

            if (recipeDetailsDto.AuthorUsername == authorizedUser)
                recipeDetailsDto.IsCanModify = true;
            else
                recipeDetailsDto.IsCanModify = false;

            recipeDetailsDto.Tags = recipe.Tags.Select(x => x.TagName).ToList();

            var likeRecipe = recipeLikes.Where(r => r.UserId == userId).ToList();

            if (likeRecipe.Count > 0)
                recipeDetailsDto.IsLiked = true;
            else
                recipeDetailsDto.IsLiked = false;

            return recipeDetailsDto;
        }
    }
}
