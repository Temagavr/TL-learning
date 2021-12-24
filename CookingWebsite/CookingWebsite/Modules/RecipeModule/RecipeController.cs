using CookingWebsite.Application.Files;
using CookingWebsite.Application.Recipes;
using CookingWebsite.Domain;
using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using CookingWebsite.Modules.RecipeModule.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeModule
{
    [ApiController]
    [Route("api/recipe")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeService recipeService, IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeService = recipeService;
            _unitOfWork = unitOfWork;
            _recipeRepository = recipeRepository;
        }

        [HttpGet("{recipeId}/details")]
        public async Task<RecipeDetailsDto> GetRecipeDetails([FromRoute] int recipeId)
        {
            var recipeDetails = await _recipeRepository.GetById(recipeId);

            return recipeDetails.Map(User.FindFirstValue(Claims.Username));
        }

        [HttpGet("search")]
        public async Task<List<RecipeCardDto>> SearchRecipes(
            [FromQuery] int skip,
            [FromQuery] int take,
            [FromQuery] string searchString)
        {
            List<Recipe> recipes = new List<Recipe>();
            recipes = await _recipeRepository.Search(skip, take, searchString, false);

            return recipes.Map();
        }
        
        [HttpPost("add-recipe")]
        public async Task AddRecipe()
        {
            IFormFileCollection files = Request.Form.Files;

            AddRecipeDto addRecipeDto = JsonConvert.DeserializeObject<AddRecipeDto>(Request.Form["data"]);

            var recipeDto = await addRecipeDto.Map(files, User.FindFirstValue(Claims.Username));

            await _recipeService.AddRecipe(recipeDto);

            await _unitOfWork.Commit();
        }

        [HttpPost("update-recipe")]
        public async Task UpdateRecipe()
        {
            IFormFileCollection files = Request.Form.Files;

            UpdateRecipeDto updateRecipeDto = JsonConvert.DeserializeObject<UpdateRecipeDto>(Request.Form["data"]);

            var recipeDto = await updateRecipeDto.Map(files);

            await _recipeService.UpdateRecipe(recipeDto);
            
            await _unitOfWork.Commit();
        }

        [HttpPost("delete/{recipeId}")]
        public async Task DeleteRecipe([FromRoute] int recipeId)
        {
            var recipe = await _recipeRepository.GetById(recipeId);

            _recipeRepository.Delete(recipe);

            await _unitOfWork.Commit();
        }
    }
}
