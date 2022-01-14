using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.SearchRecipeModule
{
    [ApiController]
    [Route("api/recipes/search")]
    public class RecipeSearchController : BaseController
    {

        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeLikeRepository _recipeLikeRepository;
        private readonly IRecipeFavouriteRepository _recipeFavouriteRepository;

        public RecipeSearchController(
            IRecipeRepository recipeRepository,
            IRecipeLikeRepository recipeLikeRepository,
            IRecipeFavouriteRepository recipeFavouriteRepository)
        {
            _recipeRepository = recipeRepository;
            _recipeLikeRepository = recipeLikeRepository;
            _recipeFavouriteRepository = recipeFavouriteRepository;
        }

        [HttpGet]
        public async Task<List<RecipeCardDto>> SearchRecipes
        (
            [FromQuery] int skip,
            [FromQuery] int take,
            [FromQuery] string searchString
        )
        {
            List<Recipe> recipes = new List<Recipe>();
            recipes = await _recipeRepository.Search(skip, take, searchString, false);
            List<RecipeLike> userLikes = await _recipeLikeRepository.GetByUserId(GetAuthorizedUserId());
            List<RecipeFavourite> userFavourites = await _recipeFavouriteRepository.GetByUserId(GetAuthorizedUserId());

            return await recipes.Map(
                userLikes,
                userFavourites,
                GetAuthorizedUserId(),
                _recipeLikeRepository,
                _recipeFavouriteRepository);
        }
    }
}
