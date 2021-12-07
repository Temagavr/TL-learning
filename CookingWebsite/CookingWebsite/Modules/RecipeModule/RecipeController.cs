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
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeModule
{
    [ApiController]
    [Route("api/recipe")]
    public class RecipeController : Controller
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

            return recipeDetails.Map();
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

            var recipeDto = addRecipeDto.Map();
            recipeDto.Image = await FileManagment.CreateAsync(files[0]);

            await _recipeService.AddRecipe(recipeDto);

            await _unitOfWork.Commit();
        }
        
    }
}
