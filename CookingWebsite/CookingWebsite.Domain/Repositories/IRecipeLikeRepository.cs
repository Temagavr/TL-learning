using CookingWebsite.Domain.Entities.Recipes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Repositories
{
    public interface IRecipeLikeRepository
    {
        void AddLike(RecipeLike recipeLike);
        void RemoveLike(RecipeLike recipeLike);
        Task<List<RecipeLike>> GetRecipeLikesCount(int recipeId);
        Task<List<RecipeLike>> GetUserLikedRecipes(int userId);
    }
}
