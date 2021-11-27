using CookingWebsite.Application.Recipes.RecipeDtos;
using CookingWebsite.Domain.Entities.Recipes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Recipes
{
    public interface IRecipeService
    {
        Task AddRecipe(AddRecipeDto addRecipeDto);
        Task DeleteRecipe(int recipeId);
        Task<Recipe> GetRecipe(int recipeId);
        Task<List<Recipe>> SearchRecipes(int skip, int take, string searchString);
        Task<Recipe> GetRecipeOfDay();
    }
}
