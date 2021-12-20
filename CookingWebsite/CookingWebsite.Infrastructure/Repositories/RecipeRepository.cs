using CookingWebsite.Domain.Repositories;
using CookingWebsite.Infrastructure.Foundation;
using CookingWebsite.Domain.Entities.Recipes;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CookingWebsite.Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly CookingWebsiteDbContext _dbContext;
        private DbSet<Recipe> _recipes => _dbContext.Set<Recipe>();

        public RecipeRepository( CookingWebsiteDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<Recipe> GetById(int recipeId)
        {
            return await _recipes
                .Include(r => r.Ingredients)
                    .ThenInclude(i => i.Items)
                .Include(r => r.Steps)
                .Include(r => r.Tags)
                .FirstOrDefaultAsync(r => r.Id == recipeId);
        }

        public void Add(Recipe recipe)
        {
            _dbContext.Add( recipe );
        }

        public void AddRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            _dbContext.Add(recipeIngredient);
        }

        public void AddRecipeIngredientItem(RecipeIngredientItem recipeIngredientItem)
        {
            _dbContext.Add(recipeIngredientItem);
        }
        public void AddRecipeStep(RecipeStep recipeStep)
        {
            _dbContext.Add(recipeStep);
        }

        public void Delete(Recipe recipe)
        {
            _dbContext.Remove(recipe);
        }

        public async Task<List<Recipe>> Search(int skip, int take, string searchString, bool includeAll)
        {
            IQueryable<Recipe> query = _recipes.AsQueryable();

            if (includeAll)
            {
                query = query.Include(r => r.Ingredients).ThenInclude(i => i.Items).Include(r => r.Tags);
            }

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                string trimedSearchString = searchString.Trim();

                query = query.Where(x => x.AuthorUsername.Contains(trimedSearchString)
                    || x.Title.Contains(trimedSearchString));
            }

            query = query.Include(r => r.Tags).OrderBy(r => r.Id).Skip(skip).Take(take);

            return await query.ToListAsync();
        }

        public async Task<Recipe> GetFirst()
        {
            return await _recipes.FirstOrDefaultAsync();
        }
    }
}
