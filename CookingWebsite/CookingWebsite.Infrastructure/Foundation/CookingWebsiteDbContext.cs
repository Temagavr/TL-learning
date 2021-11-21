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
            builder.ApplyConfiguration( new UserConfiguration() );
            builder.ApplyConfiguration( new UserStatisticConfiguration() );
        }
    }
}
