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
    [Route("api/recipes")]
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
    }
}
