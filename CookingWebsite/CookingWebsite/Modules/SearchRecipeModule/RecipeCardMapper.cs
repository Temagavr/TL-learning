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
            List<RecipeFavourite> userFavourites,
            int userId,
            IRecipeLikeRepository recipeLikeRepository,
            IRecipeFavouriteRepository recipeFavouriteRepository)
        {
            var recipeCardsList = new List<RecipeCardDto>();

            foreach (Recipe recipe in recipes)
            {
                var recipeCard = new RecipeCardDto();

                recipeCard.Title = recipe.Title;
                recipeCard.Description = recipe.Description;
                recipeCard.AuthorUsername = recipe.AuthorUsername;
                recipeCard.CookingTime = recipe.CookingTime;
                recipeCard.Id = recipe.Id;
                recipeCard.ImageUrl = recipe.ImageUrl;
                recipeCard.PersonsCount = recipe.PersonsCount;

                var recipeLikes = await recipeLikeRepository.GetByRecipeId(recipe.Id);
                recipeCard.LikesCount = recipeLikes.Count;

                var recipeFavourites = await recipeFavouriteRepository.GetByRecipeId(recipe.Id);
                recipeCard.FavouritesCount = recipeFavourites.Count;

                recipeCard.Tags = new List<string>();
                foreach(RecipeTag tag in recipe.Tags)
                {
                    recipeCard.Tags.Add(tag.TagName);
                }

                recipeCard.IsLiked = userLikes.Any(r => r.UserId == userId && r.RecipeId == recipe.Id);

                recipeCard.IsFavourite = userFavourites.Any(r => r.UserId == userId && r.RecipeId == recipe.Id);

                recipeCardsList.Add(recipeCard);
            }

            return recipeCardsList;
        }
    }
}
