using CookingWebsite.Domain;
using CookingWebsite.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeDeleteModule
{
    [ApiController]
    [Route("api/recipes/{recipeId}/delete")]
    public class RecipeDeleteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeDeleteController(IUnitOfWork unitOfWork, IRecipeRepository recipeRepository)
        {
            _unitOfWork = unitOfWork;
            _recipeRepository = recipeRepository;
        }

        [HttpPost]
        public async Task DeleteRecipe([FromRoute] int recipeId)
        {
            var recipe = await _recipeRepository.GetById(recipeId);

            _recipeRepository.Delete(recipe);

            await _unitOfWork.Commit();
        }
    }
}
