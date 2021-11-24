using CookingWebsite.Application.Recipe.RecipeDtos;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Recipe
{
    public interface IRecipeService
    {
        Task AddRecipe(AddRecipeDto addRecipeDto);
        Task DeleteRecipe(int recipeId);
        Task<Domain.Entities.Recipes.Recipe> GetRecipe(int recipeId);
    }
}
