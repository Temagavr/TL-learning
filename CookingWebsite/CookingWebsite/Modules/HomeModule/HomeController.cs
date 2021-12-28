using CookingWebsite.Application.Recipes;
using CookingWebsite.Domain;
using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.HomeModule
{
    [ApiController]
    [Route("api/home")]
    public class HomeController
    {

        private readonly IRecipeService _recipeService;
        private readonly IRecipeLikeRepository _recipeLikeRepository;

        public HomeController(IRecipeService recipeService, IRecipeLikeRepository recipeLikeRepository)
        {
            _recipeService = recipeService;
            _recipeLikeRepository = recipeLikeRepository;
        }

        [HttpGet("recipe-of-day")]
        public async Task<RecipeOfDayDto> GetRecipeOfDay()
        {
            var recipe = await _recipeService.GetRecipeOfDay();
            var recipeLikes = new List<RecipeLike>();

            if (recipe != null)
                recipeLikes = await _recipeLikeRepository.GetRecipeLikes(recipe.Id);

            return recipe.Map(recipeLikes);
        }
    }
}
