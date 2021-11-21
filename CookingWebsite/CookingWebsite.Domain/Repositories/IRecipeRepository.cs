using CookingWebsite.Domain.Entities.Recipes;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetRecipe(int recipeId);
        //Task<Recipe> GetRecipes(string username);
        void Add(Recipe recipe);
        void Remove(Task<Recipe> recipe);
    }
}
