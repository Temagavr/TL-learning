using CookingWebsite.Application.Recipes.RecipeDtos;
using CookingWebsite.Domain;
using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Recipes
{
    public class RecipeService : IRecipeService
    {

        private readonly IRecipeRepository _recipeRepostitory;
        private readonly IUnitOfWork _unitOfWork;

        private bool _includeAll = false;
        private int _skip = 0;
        private int _take = 4;


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

        public async Task<Recipe> GetRecipe(int recipeId)
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

        public async Task<List<Recipe>> SearchRecipes(int skip, int take, string searchString)
        {
            var recipesList = await _recipeRepostitory.Search(skip, take, searchString, _includeAll);

            return recipesList;
        }

        public async Task<Recipe> GetRecipeOfDay()
        {
            var recipeOfDay = await _recipeRepostitory.GetFirst();

            return recipeOfDay;
        }
    }
}
