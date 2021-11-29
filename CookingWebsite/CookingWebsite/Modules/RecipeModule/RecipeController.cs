using CookingWebsite.Application.Recipes;
using CookingWebsite.Domain;
using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
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
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeService recipeService, IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeService = recipeService;
            _unitOfWork = unitOfWork;
            _recipeRepository = recipeRepository;
        }

        [HttpGet("recipe-details")]
        public async Task<RecipeDetailsDto> GetRecipeDetails([FromQuery] int recipeId)
        {
            var recipeDetails = await _recipeRepository.GetById(recipeId);

            return recipeDetails.Map();
        }

        [HttpGet("search")]
        public async Task<List<RecipeCardDto>> SearchRecipes(
            [FromQuery] int skip,
            [FromQuery] int take,
            [FromQuery] string searchString)
        {
            List<Recipe> recipes = new List<Recipe>();
            recipes = await _recipeRepository.Search(skip, take, searchString, false);

            return recipes.Map();
        }
    }
}
