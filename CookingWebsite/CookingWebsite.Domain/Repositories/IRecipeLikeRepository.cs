using CookingWebsite.Domain.Entities.Recipes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Repositories
{
    public interface IRecipeLikeRepository
    {
        void AddLike(RecipeLike recipeLike);
        void RemoveLike(RecipeLike recipeLike);
        Task<List<RecipeLike>> GetUserLikedRecipes(int userId);
        Task<RecipeLike> GetByUserIdRecipeId(int userId, int recipeId);
    }
}
