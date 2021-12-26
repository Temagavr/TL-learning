using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookingWebsite.Infrastructure.Configurations
{
    public class RecipeLikeConfiguration : IEntityTypeConfiguration<RecipeLike>
    {
        public void Configure(EntityTypeBuilder<RecipeLike> builder)
        {
            builder.ToTable(nameof(RecipeLike)).HasKey(t => t.Id);
            /*
            builder
                .HasOne<Recipe>()
                .WithOne()
                .HasForeignKey<Recipe>(r => r.Id);

            builder
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<User>(u => u.Id);
            */
        }
    }
}
