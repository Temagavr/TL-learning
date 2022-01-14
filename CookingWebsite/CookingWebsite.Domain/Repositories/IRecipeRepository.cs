using CookingWebsite.Domain.Entities.Recipes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetById(int recipeId);
        void Add(Recipe recipe);
        void AddRecipeIngredient(RecipeIngredient recipeIngredient);
        void AddRecipeIngredientItem(RecipeIngredientItem recipeIngredientItem);
        void AddRecipeStep(RecipeStep recipeStep);
        void Delete(Recipe recipe);
        Task<List<Recipe>> Search(int skip, int take, string searchString, bool includeAll);
        Task<Recipe> GetFirst();
        Task<List<Recipe>> GetByIds(List<int> recipeIds);
    }
}
