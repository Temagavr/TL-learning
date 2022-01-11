using CookingWebsite.Application.Recipes;
using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.UserFavouritesModule
{
    [ApiController]
    [Route("api/user/favourites")]
    public class UserFavouritesController : BaseController
    {
        private readonly IRecipeService _recipeService;
        private readonly IRecipeLikeRepository _recipeLikeRepository;
        private readonly IRecipeFavouriteRepository _recipeFavouriteRepository;

        public UserFavouritesController(
            IRecipeService recipeService,
            IRecipeLikeRepository recipeLikeRepository,
            IRecipeFavouriteRepository recipeFavouriteRepository)
        {
            _recipeService = recipeService;
            _recipeLikeRepository = recipeLikeRepository;
            _recipeFavouriteRepository = recipeFavouriteRepository;
        }

        [HttpGet]
        public async Task<List<RecipeCardDto>> GetUserFavouritesRecipes()
        {
            List<Recipe> recipe = await _recipeService.GetUserFavourites(GetAuthorizedUserId());

            List<RecipeLike> userLikes = await _recipeLikeRepository.GetByUserId(GetAuthorizedUserId());
            List<RecipeFavourite> userFavourites = await _recipeFavouriteRepository.GetByUserId(GetAuthorizedUserId());

            return await recipe.Map(
                userLikes,
                userFavourites,
                GetAuthorizedUserId(),
                _recipeLikeRepository,
                _recipeFavouriteRepository);
        }
    }
}
