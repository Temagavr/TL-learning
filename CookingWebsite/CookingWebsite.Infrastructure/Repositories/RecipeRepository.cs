using CookingWebsite.Domain.Repositories;
using CookingWebsite.Infrastructure.Foundation;

namespace CookingWebsite.Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly CookingWebsiteDbContext _dbContext;

        public RecipeRepository( CookingWebsiteDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Add( Recipe recipe )
        {
            _dbContext.Add( recipe );
        }
    }
}
