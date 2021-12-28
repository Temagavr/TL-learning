using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.SearchRecipeModule
{
    public static class RecipeCardMapper
    {
        public static async Task<List<RecipeCardDto>> Map(
            this List<Recipe> recipes,
            List<RecipeLike> userLikes,
            int userId,
            IRecipeLikeRepository recipeLikeRepository)
        {
            var recipeCardsList = new List<RecipeCardDto>();

            foreach (Recipe recipe in recipes)
            {
                var recipeCard = new RecipeCardDto();

                recipeCard.Title = recipe.Title;
                recipeCard.Description = recipe.Description;
                recipeCard.AuthorUsername = recipe.AuthorUsername;
                recipeCard.CookingTime = recipe.CookingTime;
                recipeCard.FavouritesCount = 0;
                recipeCard.Id = recipe.Id;
                recipeCard.ImageUrl = recipe.ImageUrl;
                recipeCard.PersonsCount = recipe.PersonsCount;

                var recipeLikes = await recipeLikeRepository.GetRecipeLikes(recipe.Id);
                // поправить подсчет лайков у рецептов через выборку всех лайков с данным recipeId
                recipeCard.LikesCount = recipeLikes.Count;

                recipeCard.Tags = new List<string>();
                foreach(RecipeTag tag in recipe.Tags)
                {
                    recipeCard.Tags.Add(tag.TagName);
                }

                var likeRecipe = userLikes.Where(r => r.UserId == userId && r.RecipeId == recipe.Id).ToList();

                if (likeRecipe.Count > 0)
                    recipeCard.IsLiked = true;
                else
                    recipeCard.IsLiked = false;

                recipeCardsList.Add(recipeCard);
            }

            return recipeCardsList;
        }
    }
}
