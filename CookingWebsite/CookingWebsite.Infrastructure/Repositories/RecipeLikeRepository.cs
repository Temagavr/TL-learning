using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using CookingWebsite.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingWebsite.Infrastructure.Repositories
{
    public class RecipeLikeRepository : IRecipeLikeRepository
    {
        private readonly CookingWebsiteDbContext _dbContext;
        private DbSet<RecipeLike> _recipeLikes => _dbContext.Set<RecipeLike>();

        public RecipeLikeRepository(CookingWebsiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddLike(RecipeLike recipeLike)
        {
            _dbContext.Add(recipeLike);
        }

        public void RemoveLike(RecipeLike recipeLike)
        {
            _dbContext.Remove(recipeLike);
        }

        public async Task<List<RecipeLike>> GetRecipeLikesCount(int recipeId)
        {
            IQueryable<RecipeLike> query = _recipeLikes.AsQueryable();

            if (recipeId != 0)
            {
                query = query.Where(x => x.RecipeId == recipeId);
            }

            return await query.ToListAsync();
        }

        public async Task<List<RecipeLike>> GetUserLikedRecipes(int userId)
        {
            IQueryable<RecipeLike> query = _recipeLikes.AsQueryable();

            if (userId != 0)
            {
                query = query.Where(x => x.UserId == userId);
            }

            return await query.ToListAsync();
        }

        public async Task<RecipeLike> GetByUserIdRecipeId(int userId, int recipeId)
        {
            return await _recipeLikes.FirstOrDefaultAsync(r => r.RecipeId == recipeId && r.UserId == userId);
        }
    }
}
