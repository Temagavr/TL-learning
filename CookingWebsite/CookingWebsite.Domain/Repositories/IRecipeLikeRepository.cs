using CookingWebsite.Domain.Entities.Recipes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Repositories
{
    public interface IRecipeLikeRepository
    {
        void Add(RecipeLike recipeLike);
        void Remove(RecipeLike recipeLike);
        Task<List<RecipeLike>> GetByUserId(int userId);
        Task<List<RecipeLike>> GetByRecipeId(int recipeId);
        Task<RecipeLike> GetByUserIdAndRecipeId(int userId, int recipeId);
    }
}
