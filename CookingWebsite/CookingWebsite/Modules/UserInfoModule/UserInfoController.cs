using CookingWebsite.Application.Account;
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
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeLikeRepository _recipeLikeRepository;
        private readonly IRecipeFavouriteRepository _recipeFavouriteRepository;

        public UserInfoController(
            IAccountService accountService,
            IRecipeRepository recipeRepository,
            IRecipeLikeRepository recipeLikeRepository,
            IRecipeFavouriteRepository recipeFavouriteRepository
            )
        {
            _accountService = accountService;
            _recipeRepository = recipeRepository;
            _recipeLikeRepository = recipeLikeRepository;
            _recipeFavouriteRepository = recipeFavouriteRepository;
        }

        [HttpGet("info")]
        public async Task<UserInfoDto> GetUserInfo()
        {
            int userId = GetAuthorizedUserId();
            User user = await _accountService.GetUserInfo(userId);
            //List<Recipe> recipes = await _recipeRepository.
            List<RecipeLike> userLikes = await _recipeLikeRepository.GetByUserId(userId);
            List<RecipeFavourite> userFavourites = await _recipeFavouriteRepository.GetByUserId(userId);

            int skip = 0;
            int take = 100;
            string userName = GetAuthorizedUserUsername();
            List<Recipe> recipes = new List<Recipe>();
            recipes = await _recipeRepository.Search(skip, take, userName, false);

            return user.Map(userLikes, userFavourites, recipes);
        }
        /*
        [HttpGet("recipes")]
        public async Task<RecipeCardDto> GetUserRecipes()
        {

        }
        */
        
    }
}
