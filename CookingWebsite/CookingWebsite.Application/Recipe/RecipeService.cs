using CookingWebsite.Application.Dtos.RecipeDtos;
using CookingWebsite.Domain;
using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingWebsite.Application
{
    public class RecipeService
    {

        private readonly IRecipeRepository _recipeRepostitory;

        //private readonly IUserRepository _userRepostitory;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeService(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeRepostitory = recipeRepository;
            _unitOfWork = unitOfWork;
            //_userRepostitory = userRepository;
        }

        public async Task AddRecipe (AddRecipeDto addRecipeDto)
        {
            var recipe = new Recipe(
                "image",
                addRecipeDto.Title,
                addRecipeDto.Description,
                addRecipeDto.CookingTime,
                addRecipeDto.PersonsCount,
                0,
                0,
                "author"
                );

            await _unitOfWork.Commit();
        }

        public async Task DeleteRecipe(int recipeId)
        {
            var recipe = _recipeRepostitory.GetRecipe(recipeId);

            _recipeRepostitory.Remove(recipe);
            await _unitOfWork.Commit();
        }
    }
}
