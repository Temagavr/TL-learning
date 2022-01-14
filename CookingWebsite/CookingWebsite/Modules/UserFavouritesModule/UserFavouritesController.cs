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
        private readonly IRecipeCardBuilder _recipeCardBuilder;

        public UserFavouritesController(
            IRecipeService recipeService,
            IRecipeCardBuilder recipeCardBuilder)
        {
            _recipeService = recipeService;
            _recipeCardBuilder = recipeCardBuilder;
        }

        [HttpGet]
        public async Task<List<RecipeCardDto>> GetUserFavouritesRecipes(
            [FromQuery] int skip,
            [FromQuery] int take)
        {
            int authorizedUserId = GetAuthorizedUserId();
            List<Recipe> recipes = await _recipeService.GetUserFavourites(skip, take, authorizedUserId);

            return await _recipeCardBuilder.Build(recipes, authorizedUserId);
        }
    }
}
