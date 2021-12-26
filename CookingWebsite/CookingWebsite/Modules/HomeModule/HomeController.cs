using CookingWebsite.Application.Recipes;
using CookingWebsite.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.HomeModule
{
    [ApiController]
    [Route("api/home")]
    public class HomeController
    {

        private readonly IRecipeService _recipeService;

        public HomeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

		[HttpGet("recipe-of-day")]
        public async Task<RecipeOfDayDto> GetRecipeOfDay()
		{
            var recipe = await _recipeService.GetRecipeOfDay();

            if (recipe != null)
                return recipe.Map();
            else
                return null;
        }
        
    }
}
