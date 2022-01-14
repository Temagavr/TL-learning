using CookingWebsite.Domain;
using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeDetailsModule
{
    [ApiController]
    [Route("api/recipes/{recipeId}")]
    public class RecipeDetailsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeLikeRepository _recipeLikeRepository;
        private readonly IRecipeFavouriteRepository _recipeFavouriteRepository;

        public RecipeDetailsController(
            IUnitOfWork unitOfWork,
            IRecipeRepository recipeRepository,
            IRecipeLikeRepository recipeLikeRepository,
            IRecipeFavouriteRepository recipeFavouriteRepository)
        {
            _unitOfWork = unitOfWork;
            _recipeRepository = recipeRepository;
            _recipeLikeRepository = recipeLikeRepository;
            _recipeFavouriteRepository = recipeFavouriteRepository;
        }

        [HttpGet("details")]
        public async Task<RecipeDetailsDto> GetRecipeDetails([FromRoute] int recipeId)
        {
            var recipeDetails = await _recipeRepository.GetById(recipeId);
            List<RecipeLike> recipeLikes = await _recipeLikeRepository.GetByRecipeId(recipeId);
            List<RecipeFavourite> recipeFavourites = await _recipeFavouriteRepository.GetByRecipeId(recipeId);

            return recipeDetails.Map(
                GetAuthorizedUserUsername(),
                recipeLikes,
                recipeFavourites,
                GetAuthorizedUserId());
        }

        [HttpPost("delete")]
        public async Task DeleteRecipe([FromRoute] int recipeId)
        {
            var recipe = await _recipeRepository.GetById(recipeId);

            _recipeRepository.Delete(recipe);

            await _unitOfWork.Commit();
        }
    }

}
