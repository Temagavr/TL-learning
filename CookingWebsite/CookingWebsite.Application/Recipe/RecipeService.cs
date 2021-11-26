using CookingWebsite.Application.Recipe.RecipeDtos;
using CookingWebsite.Domain;
using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Recipe
{
    public class RecipeService : IRecipeService
    {

        private readonly IRecipeRepository _recipeRepostitory;
        private readonly IUnitOfWork _unitOfWork;

        private int _skip = 0;
        private int _take = 4;
        private bool _includeAll = false;

        public RecipeService(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeRepostitory = recipeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddRecipe (AddRecipeDto addRecipeDto)
        {
            var recipe = new Domain.Entities.Recipes.Recipe(
                imageUrl: "image",
                addRecipeDto.Title,
                addRecipeDto.Description,
                addRecipeDto.CookingTime,
                addRecipeDto.PersonsCount,
                likesCount: 0,
                favouritesCount: 0,
                addRecipeDto.AuthorUsername
            );

            _recipeRepostitory.Add(recipe);

            await _unitOfWork.Commit();
        }

        public async Task<Domain.Entities.Recipes.Recipe> GetRecipe(int recipeId)
        {
            var recipe = await _recipeRepostitory.GetById(recipeId);

            return recipe;
        }

        public async Task DeleteRecipe(int recipeId)
        {
            var recipe = _recipeRepostitory.GetById(recipeId);

            _recipeRepostitory.Delete(recipe);

            await _unitOfWork.Commit();
        }

        public async Task<List<Domain.Entities.Recipes.Recipe>> SearchRecipes(string searchString)
        {
            _skip = 0;
            _take = 4;

            var recipesList = await _recipeRepostitory.Search(_skip, _take, searchString, _includeAll);

            _skip = _take;
            _take = 2;

            return recipesList;
        }

        public async Task<List<Domain.Entities.Recipes.Recipe>> LoadMoreRecipes(string searchString)
        {
            var recipesList = await _recipeRepostitory.Search(_skip, _take, searchString, _includeAll);
            _skip += _take;

            return recipesList;
        }
    }
}
