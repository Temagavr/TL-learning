using CookingWebsite.Domain.Repositories;
using CookingWebsite.Infrastructure.Foundation;
using CookingWebsite.Domain.Entities.Recipes;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
            return await _recipes.FirstOrDefaultAsync(r => r.Id == recipeId);
        }
        /*
        public async Task<Recipe> GetRecipes(string username)
        {
            return await _recipes.AllAsync<Recipe>(r => r.AuthorUsername == username);
        }
        */

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

        public void Remove(Task<Recipe> recipe)
        {
            _dbContext.Remove(recipe);
        }
    }
}
