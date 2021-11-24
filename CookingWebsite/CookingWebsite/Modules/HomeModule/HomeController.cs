using CookingWebsite.Application.Account;
using CookingWebsite.Application.Recipe;
using CookingWebsite.Domain;
using CookingWebsite.Domain.Entities.Recipes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.HomeModule
{
    [ApiController]
    [Route("api/home")]
    public class HomeController
    {

        private readonly IRecipeService _recipeService;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IRecipeService recipeService, IUnitOfWork unitOfWork)
        {
            _recipeService = recipeService;
            _unitOfWork = unitOfWork;
        }

		[HttpGet("recipeOfDay")]
        public async Task<RecipeOfDayDto> GetRecipeOfDay()
		{
            var recipe = await _recipeService.GetRecipe(1);

            return recipe.Map();
        }
        
    }
}
