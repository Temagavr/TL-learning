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
        private readonly IRecipeCardBuilder _recipeCardBuilder;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeSearchController(
            IRecipeCardBuilder recipeCardBuilder,
            IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
            _recipeCardBuilder = recipeCardBuilder;
        }

        [HttpGet]
        public async Task<List<RecipeCardDto>> SearchRecipes
        (
            [FromQuery] int skip,
            [FromQuery] int take,
            [FromQuery] string searchString)
        {
            List<Recipe> recipes = new List<Recipe>();
            int authorizedUserId = GetAuthorizedUserId();
            recipes = await _recipeRepository.Search(skip, take, searchString, false);

            return await _recipeCardBuilder.Build(recipes, authorizedUserId);
        }
    }
}
