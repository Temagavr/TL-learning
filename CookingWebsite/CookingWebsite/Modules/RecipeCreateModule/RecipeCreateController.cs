using CookingWebsite.Application.Recipes;
using CookingWebsite.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeCreateModule
{
    [ApiController]
    [Route("api/recipes/create")]
    public class RecipeCreateController : ControllerBase
    {

        private readonly IRecipeService _recipeService;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeCreateController(IUnitOfWork unitOfWork, IRecipeService recipeService)
        {
            _unitOfWork = unitOfWork;
            _recipeService = recipeService;
        }

        [HttpPost]
        public async Task AddRecipe()
        {
            IFormFileCollection files = Request.Form.Files;

            AddRecipeDto addRecipeDto = JsonConvert.DeserializeObject<AddRecipeDto>(Request.Form["data"]);

            var recipeDto = await addRecipeDto.Map(files, User.FindFirstValue(Claims.Username));

            await _recipeService.AddRecipe(recipeDto);

            await _unitOfWork.Commit();
        }
    }
}
