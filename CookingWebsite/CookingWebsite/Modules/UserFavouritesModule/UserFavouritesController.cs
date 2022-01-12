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
        public async Task<List<RecipeCardDto>> GetUserFavouritesRecipes(
            [FromQuery] int skip,
            [FromQuery] int take)
        {
            int authorizedUserId = GetAuthorizedUserId();
            List<Recipe> recipes = await _recipeService.GetUserFavourites(skip, take, authorizedUserId);

            RecipeCardBuilder builder = new RecipeCardBuilder(_recipeLikeRepository, _recipeFavouriteRepository);

            return await builder.Build(recipes, authorizedUserId);
        }
    }
}
