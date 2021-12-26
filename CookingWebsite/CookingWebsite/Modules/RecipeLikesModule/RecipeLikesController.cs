using CookingWebsite.Domain;
using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeLikesModule
{
    [ApiController]
    [Route("api/recipes/{recipeId}/likes")]
    public class RecipeLikesController : ControllerBase
    {
        private readonly IRecipeLikeRepository _recipeLikeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeLikesController(IRecipeLikeRepository recipeLikeRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _recipeLikeRepository = recipeLikeRepository;
        }

        [HttpPost("add")]
        public async Task AddLike([FromRoute] int recipeId)
        {

            RecipeLike recipeLike = new RecipeLike(
                Convert.ToInt32(User.FindFirstValue(Claims.UserId)),
                recipeId);

            _recipeLikeRepository.AddLike(recipeLike);

            await _unitOfWork.Commit();
        }

        [HttpPost("remove")]
        public async Task removeLike([FromRoute] int recipeId)
        {
            var recipeLike = await _recipeLikeRepository.GetByUserIdRecipeId(
                Convert.ToInt32(User.FindFirstValue(Claims.UserId)),
                recipeId
                );

            _recipeLikeRepository.RemoveLike(recipeLike);

            await _unitOfWork.Commit();
        }
    }
}
