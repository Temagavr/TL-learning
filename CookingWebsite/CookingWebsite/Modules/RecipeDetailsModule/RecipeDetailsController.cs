﻿using CookingWebsite.Domain;
using CookingWebsite.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public RecipeDetailsController(
            IUnitOfWork unitOfWork,
            IRecipeRepository recipeRepository,
            IRecipeLikeRepository recipeLikeRepository)
        {
            _unitOfWork = unitOfWork;
            _recipeRepository = recipeRepository;
            _recipeLikeRepository = recipeLikeRepository;
        }

        [HttpGet("details")]
        public async Task<RecipeDetailsDto> GetRecipeDetails([FromRoute] int recipeId)
        {
            var recipeDetails = await _recipeRepository.GetById(recipeId);
            var recipeLikes = await _recipeLikeRepository.GetByRecipeId(recipeId);

            return recipeDetails.Map(
                GetAuthorizedUserUsername(),
                recipeLikes,
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
