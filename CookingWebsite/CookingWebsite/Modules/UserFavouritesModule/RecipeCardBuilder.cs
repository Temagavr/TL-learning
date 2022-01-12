using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.UserFavouritesModule
{
    public class RecipeCardBuilder
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

            return await recipes.Map(
                userLikes,
                userFavourites,
                authorizedUserId,
                _recipeLikeRepository,
                _recipeFavouriteRepository);
        }
    }
}
