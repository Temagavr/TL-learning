using CookingWebsite.Application.Recipes;
using CookingWebsite.Domain;
using CookingWebsite.Domain.Entities.Users;
using CookingWebsite.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeCreateUpdateModule
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipeCreateUpdateController : BaseController
    {

        private readonly IRecipeService _recipeService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeCreateUpdateController(
            IUnitOfWork unitOfWork,
            IRecipeService recipeService,
            IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _recipeService = recipeService;
            _userRepository = userRepository;
        }

        [HttpPost("create")]
        public async Task AddRecipe()
        {
            IFormFileCollection files = Request.Form.Files;

            AddRecipeDto addRecipeDto = JsonConvert.DeserializeObject<AddRecipeDto>(Request.Form["data"]);
            
            var userId = GetAuthorizedUserId();
            User user = await _userRepository.GetById(userId);
            var recipeDto = await addRecipeDto.Map(files, user.Login);

            await _recipeService.AddRecipe(recipeDto, userId);

            await _unitOfWork.Commit();
        }

        [HttpPost("{recipeId}/update")]
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
