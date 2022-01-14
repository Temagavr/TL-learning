using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.UserFavouritesModule
{
    public class RecipeCardBuilder : IRecipeCardBuilder
    {
        private readonly IRecipeLikeRepository _recipeLikeRepository;
        private readonly IRecipeFavouriteRepository _recipeFavouriteRepository;

        public RecipeCardBuilder(
            IRecipeLikeRepository recipeLikeRepository,
            IRecipeFavouriteRepository recipeFavouriteRepository)
        {
            _recipeLikeRepository = recipeLikeRepository;
            _recipeFavouriteRepository = recipeFavouriteRepository;
        }

        public async Task<List<RecipeCardDto>> Build(List<Recipe> recipes, int authorizedUserId)
        {
            List<RecipeLike> userLikes = await _recipeLikeRepository.GetByUserId(authorizedUserId);
            List<RecipeFavourite> userFavourites = await _recipeFavouriteRepository.GetByUserId(authorizedUserId);
            List<RecipeCardDto> recipeCards = new List<RecipeCardDto>();

            foreach(Recipe recipe in recipes)
            {
                List<RecipeLike> recipeLikes = await _recipeLikeRepository.GetByRecipeId(recipe.Id);

                List<RecipeFavourite> recipeFavourites = await _recipeFavouriteRepository.GetByRecipeId(recipe.Id);

                recipeCards.Add(recipe.Map(
                    userLikes,
                    userFavourites,
                    authorizedUserId,
                    recipeLikes,
                    recipeFavourites));
            }

            return recipeCards;
        }
    }
}
