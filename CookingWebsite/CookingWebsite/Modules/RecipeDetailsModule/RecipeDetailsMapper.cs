using CookingWebsite.Domain.Entities.Recipes;
using System.Collections.Generic;
using System.Linq;

namespace CookingWebsite.Modules.RecipeDetailsModule
{
    public static class RecipeDetailsMapper
    {
        public static RecipeDetailsDto Map(
            this Recipe recipe,
            List<RecipeLike> recipeLikes,
            List<RecipeFavourite> recipeFavourites,
            int userId)
        {
            var recipeDetailsDto = new RecipeDetailsDto();

            recipeDetailsDto.Title = recipe.Title;
            recipeDetailsDto.Description = recipe.Description;
            recipeDetailsDto.AuthorUsername = recipe.AuthorUsername;
            recipeDetailsDto.CookingTime = recipe.CookingTime;
            recipeDetailsDto.FavouritesCount = recipeFavourites.Count;
            recipeDetailsDto.Id = recipe.Id;
            recipeDetailsDto.ImageUrl = recipe.ImageUrl;
            recipeDetailsDto.LikesCount = recipeLikes.Count;
            recipeDetailsDto.PersonsCount = recipe.PersonsCount;

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

            if (recipe.AuthorId == userId)
                recipeDetailsDto.IsCanModify = true;
            else
                recipeDetailsDto.IsCanModify = false;

            recipeDetailsDto.Tags = recipe.Tags.Select(x => x.TagName).ToList();

            recipeDetailsDto.IsLiked = recipeLikes.Any(x => x.UserId == userId);

            recipeDetailsDto.IsFavourite = recipeFavourites.Any(x => x.UserId == userId);

            return recipeDetailsDto;
        }
    }
}
