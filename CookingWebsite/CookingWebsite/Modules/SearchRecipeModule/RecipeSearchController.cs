using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.SearchRecipeModule
{
    [ApiController]
    [Route("api/recipes/search")]
    public class RecipeSearchController : ControllerBase
    {

        private readonly IRecipeRepository _recipeRepository;
        public RecipeSearchController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
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

            return recipes.Map();
        }
    }
}
