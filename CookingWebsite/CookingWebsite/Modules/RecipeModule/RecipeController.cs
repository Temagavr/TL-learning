using CookingWebsite.Application.Recipe;
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

        [HttpPost("recipeDetails/{recipeId}")]
        public async Task<RecipeDetailsDto> GetRecipeDetails(int recipeId)
        {
            var recipeDetails = await _recipeService.GetRecipe(recipeId);

            return recipeDetails.Map();
        }

        [HttpPost("searchRecipes")]
        public async Task<List<RecipeCardDto>> SearchRecipes(string searchString)
        {
            var recipesList = await _recipeService.SearchRecipes(searchString);

            return recipesList.Map();
        }

        [HttpPost("loadMoreRecipes")]
        public async Task<List<RecipeCardDto>> LoadMoreRecipes(LoadMoreRecipesDto loadMore)
        {
            var recipesList = await _recipeService.LoadMoreRecipes(loadMore.Skip, loadMore.Take, loadMore.SearchString);

            return recipesList.Map();
        }
    }
}
