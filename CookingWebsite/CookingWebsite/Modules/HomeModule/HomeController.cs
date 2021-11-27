using CookingWebsite.Application.Account;
using CookingWebsite.Application.Recipes;
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

		[HttpGet("recipe-of-day")]
        public async Task<RecipeOfDayDto> GetRecipeOfDay()
		{
            var recipe = await _recipeService.GetRecipeOfDay();

            return recipe.Map();
        }
        
    }
}
