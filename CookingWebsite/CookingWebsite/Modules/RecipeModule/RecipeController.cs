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

        [HttpGet("recipeDetails")]
        public async Task<RecipeDetailsDto> GetRecipeDetails(int recipeId)
        {
            var recipeDetails = await _recipeService.GetRecipe(recipeId);

            return recipeDetails.Map();
        }

        /*
        [HttpGet("/recipes")]
        public async Task<List<RecipeDetailsDto>> SearchRecipes(string searchString)
        {


            return new List<RecipeDetailsDto>();
        }*/
    }
}
