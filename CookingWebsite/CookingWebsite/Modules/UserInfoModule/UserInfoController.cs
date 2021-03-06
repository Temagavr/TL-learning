using CookingWebsite.Application.Account;
using CookingWebsite.Domain;
using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Entities.Users;
using CookingWebsite.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.UserInfoModule
{
    [ApiController]
    [Route("api/user")]
    public class UserInfoController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IUserRepository _userRepository;
        private readonly IRecipeCardBuilder _recipeCardBuilder;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeLikeRepository _recipeLikeRepository;
        private readonly IRecipeFavouriteRepository _recipeFavouriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserInfoController(
            IAccountService accountService,
            IUserRepository userRepository,
            IRecipeCardBuilder recipeCardBuilder,
            IRecipeRepository recipeRepository,
            IRecipeLikeRepository recipeLikeRepository,
            IRecipeFavouriteRepository recipeFavouriteRepository,
            IUnitOfWork unitOfWork)
        {
            _accountService = accountService;
            _userRepository = userRepository;
            _recipeCardBuilder = recipeCardBuilder;
            _recipeRepository = recipeRepository;
            _recipeLikeRepository = recipeLikeRepository;
            _recipeFavouriteRepository = recipeFavouriteRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("info")]
        public async Task<UserInfoDto> GetUserInfo()
        {
            int userId = GetAuthorizedUserId();
            User user = await _userRepository.GetById(userId);
            List<RecipeLike> userLikes = await _recipeLikeRepository.GetByUserId(userId);
            List<RecipeFavourite> userFavourites = await _recipeFavouriteRepository.GetByUserId(userId);

            int skip = 0;
            int take = 100;
            List<Recipe> recipes = new List<Recipe>();
            recipes = await _recipeRepository.GetUserRecipes(skip, take, userId);

            return user.Map(userLikes, userFavourites, recipes);
        }
        
        [HttpGet("recipes")]
        public async Task<List<RecipeCardDto>> GetUserRecipes(
            [FromQuery] int skip,
            [FromQuery] int take)
        {
            int authorizedUserId = GetAuthorizedUserId();
            List<Recipe> recipes = await _recipeRepository.GetUserRecipes(skip, take, authorizedUserId);

            return await _recipeCardBuilder.Build(recipes, authorizedUserId);
        }   

        [HttpPost("change/name")]
        public async Task ChangeName([FromQuery] string newValue)
        {
            int userId = GetAuthorizedUserId();
            await _accountService.ChangeName(userId, newValue);

            await _unitOfWork.Commit();
        }

        [HttpPost("change/login")]
        public async Task ChangeLogin([FromQuery] string newValue)
        {
            int userId = GetAuthorizedUserId();
            await _accountService.ChangeLogin(userId, newValue);

            await _unitOfWork.Commit();
        }

        [HttpPost("change/password")]
        public async Task ChangePassword([FromQuery] string newValue)
        {
            int userId = GetAuthorizedUserId();
            await _accountService.ChangePassword(userId, newValue);

            await _unitOfWork.Commit();
        }

        [HttpPost("change/description")]
        public async Task ChangeDescription([FromQuery] string newValue)
        {
            int userId = GetAuthorizedUserId();
            await _accountService.ChangeDescription(userId, newValue);

            await _unitOfWork.Commit();
        }
    }
}
