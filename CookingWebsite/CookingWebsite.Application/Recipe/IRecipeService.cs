using CookingWebsite.Application.Recipe.RecipeDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Recipe
{
    public interface IRecipeService
    {
        Task AddRecipe(AddRecipeDto addRecipeDto);
        Task DeleteRecipe(int recipeId);
        Task<Domain.Entities.Recipes.Recipe> GetRecipe(int recipeId);
        Task<List<Domain.Entities.Recipes.Recipe>> SearchRecipes(string searchString);
        Task<List<Domain.Entities.Recipes.Recipe>> LoadMoreRecipes(string searchString);
    }
}
