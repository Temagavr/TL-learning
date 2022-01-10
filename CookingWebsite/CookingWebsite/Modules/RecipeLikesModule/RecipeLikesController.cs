using CookingWebsite.Application.Recipes;
using CookingWebsite.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeLikesModule
{
    [ApiController]
    [Route("api/recipes/{recipeId}/likes")]
    public class RecipeLikesController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecipeService _recipeService;

        public RecipeLikesController(
            IUnitOfWork unitOfWork,
            IRecipeService recipeService
            )
        {
            _unitOfWork = unitOfWork;
            _recipeService = recipeService;
        }

        [HttpPost("add")]
        public async Task AddLike([FromRoute] int recipeId)
        {
            await _recipeService.AddLike(recipeId, GetAuthorizedUserId());
            
            await _unitOfWork.Commit();
        }

        [HttpPost("remove")]
        public async Task removeLike([FromRoute] int recipeId)
        {
            await _recipeService.RemoveLike(GetAuthorizedUserId(), recipeId);

            await _unitOfWork.Commit();
        }
    }
}
