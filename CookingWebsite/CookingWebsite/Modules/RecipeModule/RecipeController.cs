using CookingWebsite.Application.Recipe;
using CookingWebsite.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeModule
{
    [ApiController]
    [Route("api/home")]
    public class RecipeController
    {
        private readonly IRecipeService _recipeService;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeController(IRecipeService recipeService, IUnitOfWork unitOfWork)
        {
            _recipeService = recipeService;
            _unitOfWork = unitOfWork;
        }


        public async Task<RecipeDetailsDto> GetRecipeDetails(int recipeId)
        {
            var recipeDetails = await _recipeService.GetRecipe(recipeId);

            return recipeDetails.Map();
        }

    }
}
