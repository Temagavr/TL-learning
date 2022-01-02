using CookingWebsite.Domain.Entities.Recipes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Repositories
{
    public interface IRecipeFavouriteRepository
    {
        void Add(RecipeFavourite recipeLike);
        void Remove(RecipeFavourite recipeLike);
        Task<List<RecipeFavourite>> GetByUserId(int userId);
        Task<List<RecipeFavourite>> GetByRecipeId(int recipeId);
        Task<RecipeFavourite> GetByUserIdAndRecipeId(int userId, int recipeId);
    }
}
