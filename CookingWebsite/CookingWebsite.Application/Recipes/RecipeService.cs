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

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepostitory = recipeRepository;
        }


        public async Task<Recipe> GetRecipeOfDay()
        {
            var recipeOfDay = await _recipeRepostitory.GetFirst();

            return recipeOfDay;
        }
    }
}
