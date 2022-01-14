using CookingWebsite.Application.Recipes;
using CookingWebsite.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeFavouritesModule
{
    [ApiController]
    [Route("api/recipes/{recipeId}/favourites")]
    public class RecipeFavouritesController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecipeService _recipeService;

        public RecipeFavouritesController(
            IUnitOfWork unitOfWork,
            IRecipeService recipeService)
        {
            _unitOfWork = unitOfWork;
            _recipeService = recipeService;
        }

        [HttpPost("add")]
        public async Task AddFavourite([FromRoute] int recipeId)
        {
            await _recipeService.AddFavourite(recipeId, GetAuthorizedUserId());

            await _unitOfWork.Commit();
        }

        [HttpPost("remove")]
        public async Task removeFavourite([FromRoute] int recipeId)
        {
            await _recipeService.RemoveFavourite(GetAuthorizedUserId(), recipeId);

            await _unitOfWork.Commit();
        }
    }
}
