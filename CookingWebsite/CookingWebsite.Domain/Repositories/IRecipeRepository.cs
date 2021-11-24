using CookingWebsite.Domain.Entities.Recipes;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetById(int recipeId);
        void Add(Recipe recipe);
        void AddRecipeIngredient(RecipeIngredient recipeIngredient);
        void AddRecipeIngredientItem(RecipeIngredientItem recipeIngredientItem);
        void Delete(Task<Recipe> recipe);
    }
}
