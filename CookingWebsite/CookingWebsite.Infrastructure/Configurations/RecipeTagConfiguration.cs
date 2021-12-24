using CookingWebsite.Domain.Entities.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CookingWebsite.Infrastructure.Configurations
{
    public class RecipeTagConfiguration : IEntityTypeConfiguration<RecipeTag>
    {
        public void Configure(EntityTypeBuilder<RecipeTag> builder)
        {
            builder.ToTable(nameof(RecipeTag)).HasKey(t => t.Id);
        }
    }
}
