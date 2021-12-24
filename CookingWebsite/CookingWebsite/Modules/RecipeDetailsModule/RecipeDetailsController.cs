using CookingWebsite.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeDetailsModule
{
    [ApiController]
    [Route("api/recipes/{recipeId}/details")]
    public class RecipeDetailsController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeDetailsController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        public async Task<RecipeDetailsDto> GetRecipeDetails([FromRoute] int recipeId)
        {
            var recipeDetails = await _recipeRepository.GetById(recipeId);

            return recipeDetails.Map(User.FindFirstValue(Claims.Username));
        }
    }

}
