using CookingWebsite.Domain.Entities.Recipes;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetById(int recipeId);
        //Task<Recipe> GetByUsername(string username);
        void Add(Recipe recipe);
        void AddRecipeIngredient(RecipeIngredient recipeIngredient);
        void AddRecipeIngredientItem(RecipeIngredientItem recipeIngredientItem);
        void Remove(Task<Recipe> recipe);
    }
}
