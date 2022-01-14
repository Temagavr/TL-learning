using CookingWebsite.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CookingWebsite.Infrastructure.Foundation
{
    public class CookingWebsiteDbContext : DbContext
    {
        public CookingWebsiteDbContext(DbContextOptions<CookingWebsiteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //User
            builder.ApplyConfiguration( new UserConfiguration() );
            builder.ApplyConfiguration( new UserStatisticConfiguration() );

            //Recipe
            builder.ApplyConfiguration( new RecipeConfiguration() );
            builder.ApplyConfiguration( new RecipeIngredientConfiguration() ); 
            builder.ApplyConfiguration( new RecipeIngredientItemConfiguration() );
            builder.ApplyConfiguration( new RecipeStepConfiguration() );
            builder.ApplyConfiguration( new RecipeLikeConfiguration() );
            builder.ApplyConfiguration( new RecipeFavouriteConfiguration() );
        }
    }
}
