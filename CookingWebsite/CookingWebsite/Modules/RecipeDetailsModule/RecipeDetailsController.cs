using CookingWebsite.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeDetailsModule
{
    [ApiController]
    [Route("api/recipes/{recipeId}/details")]
    public class RecipeDetailsController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeLikeRepository _recipeLikeRepository;

        public RecipeDetailsController(IRecipeRepository recipeRepository, IRecipeLikeRepository recipeLikeRepository)
        {
            _recipeRepository = recipeRepository;
            _recipeLikeRepository = recipeLikeRepository;
        }

        [HttpGet]
        public async Task<RecipeDetailsDto> GetRecipeDetails([FromRoute] int recipeId)
        {
            var recipeDetails = await _recipeRepository.GetById(recipeId);
            var userLikes = await _recipeLikeRepository.GetUserLikedRecipes(Convert.ToInt32(User.FindFirstValue(Claims.UserId)));

            return recipeDetails.Map(
                User.FindFirstValue(Claims.Username),
                userLikes,
                Convert.ToInt32(User.FindFirstValue(Claims.UserId))
                );
        }
    }

}
