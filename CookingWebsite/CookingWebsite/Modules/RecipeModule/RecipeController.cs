using CookingWebsite.Application.Recipes;
using CookingWebsite.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeModule
{
    [ApiController]
    [Route("api/recipe")]
    public class RecipeController
    {
        private readonly IRecipeService _recipeService;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeController(IRecipeService recipeService, IUnitOfWork unitOfWork)
        {
            _recipeService = recipeService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("recipe-details")]
        public async Task<RecipeDetailsDto> GetRecipeDetails([FromQuery] int recipeId)
        {
            var recipeDetails = await _recipeService.GetRecipe(recipeId);

            return recipeDetails.Map();
        }

        [HttpGet("search")]
        public async Task<List<RecipeCardDto>> SearchRecipes(
            [FromQuery] int skip,
            [FromQuery] int take,
            [FromQuery] string searchString)
        {
            var recipesList = await _recipeService.SearchRecipes(skip, take, searchString);

            return recipesList.Map();
        }

        [HttpGet("load-more-recipes")]
        public async Task<List<RecipeCardDto>> LoadMoreRecipes(
            [FromQuery] int skip,
            [FromQuery] int take,
            [FromQuery] string searchString)
        {
            var recipesList = await _recipeService.SearchRecipes(skip, take, searchString);

            return recipesList.Map();
        }
    }
}
