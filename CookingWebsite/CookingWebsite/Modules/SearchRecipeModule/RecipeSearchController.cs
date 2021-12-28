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
    public class RecipeSearchController : ControllerBase
    {

        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeLikeRepository _recipeLikeRepository;
        public RecipeSearchController(IRecipeRepository recipeRepository, IRecipeLikeRepository recipeLikeRepository)
        {
            _recipeRepository = recipeRepository;
            _recipeLikeRepository = recipeLikeRepository;
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
            var userLikes = await _recipeLikeRepository.GetUserLikedRecipes(Convert.ToInt32(User.FindFirstValue(Claims.UserId)));

            return await recipes.Map(
                userLikes,
                Convert.ToInt32(User.FindFirstValue(Claims.UserId)),
                _recipeLikeRepository);
        }
    }
}
