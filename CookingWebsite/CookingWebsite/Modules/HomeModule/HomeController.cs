using CookingWebsite.Application.Account;
using CookingWebsite.Application.Recipe;
using CookingWebsite.Domain;
using Microsoft.AspNetCore.Mvc;

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
        public RecipeOfDayDto GetRecipeOfDay
		{
            var recipe = _recipeService.GetRecipe(1);
            return true;
            return new RecipeOfDayDto();

            //return recipe.Map();
        }
        
    }
}
