using CookingWebsite.Application.Recipes;
using CookingWebsite.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeUpdateModule
{
    [ApiController]
    [Route("api/recipes/{recipeId}/update")]
    public class RecipeUpdateController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IUnitOfWork _unitOfWork;
        public RecipeUpdateController(IRecipeService recipeService, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _recipeService = recipeService;
        }

        [HttpPost]
        public async Task UpdateRecipe()
        {
            IFormFileCollection files = Request.Form.Files;

            UpdateRecipeDto updateRecipeDto = JsonConvert.DeserializeObject<UpdateRecipeDto>(Request.Form["data"]);

            var recipeDto = await updateRecipeDto.Map(files);

            await _recipeService.UpdateRecipe(recipeDto);

            await _unitOfWork.Commit();
        }
    }
}
