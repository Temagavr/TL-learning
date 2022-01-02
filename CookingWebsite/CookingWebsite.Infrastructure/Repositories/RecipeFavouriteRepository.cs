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
    public class RecipeFavouriteRepository : IRecipeFavouriteRepository
    {
        private readonly CookingWebsiteDbContext _dbContext;
        private DbSet<RecipeFavourite> _recipeFavourites => _dbContext.Set<RecipeFavourite>();

        public RecipeFavouriteRepository(CookingWebsiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(RecipeFavourite recipeFavourite)
        {
            _dbContext.Add(recipeFavourite);
        }

        public void Remove(RecipeFavourite recipeFavourite)
        {
            _dbContext.Remove(recipeFavourite);
        }

        public async Task<List<RecipeFavourite>> GetByUserId(int userId)
        {
            IQueryable<RecipeFavourite> query = _recipeFavourites.AsQueryable();

            query = query.Where(x => x.UserId == userId);

            return await query.ToListAsync();
        }

        public async Task<List<RecipeFavourite>> GetByRecipeId(int recipeId)
        {
            IQueryable<RecipeFavourite> query = _recipeFavourites.AsQueryable();

            query = query.Where(x => x.RecipeId == recipeId);

            return await query.ToListAsync();
        }

        public async Task<RecipeFavourite> GetByUserIdAndRecipeId(int userId, int recipeId)
        {
            return await _recipeFavourites.FirstOrDefaultAsync(r => r.RecipeId == recipeId && r.UserId == userId);
        }
    }
}
