using CookingWebsite.Application.Recipes.RecipeDtos;
using CookingWebsite.Domain.Entities.Recipes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Recipes
{
    public interface IRecipeService
    {
        Task<Recipe> GetRecipeOfDay();
        Task AddRecipe(AddRecipeDto addRecipeDto);
        Task UpdateRecipe(UpdateRecipeDto updateRecipeDto);
        void AddLike(int recipeId, int userId);
        Task RemoveLike(int recipeId, int userId);
    }
}
