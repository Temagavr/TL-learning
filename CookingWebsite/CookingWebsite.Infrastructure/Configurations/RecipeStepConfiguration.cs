using CookingWebsite.Domain.Entities.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingWebsite.Infrastructure.Configurations
{
    public class RecipeStepConfiguration : IEntityTypeConfiguration<RecipeStep>
    {
        public void Configure(EntityTypeBuilder<RecipeStep> builder)
        {
            builder.ToTable(nameof(RecipeStep)).HasKey(t => t.Id);

            /*
            builder
                .HasOne<Recipe>()
                .WithOne()
                .HasForeignKey<RecipeStep>(s => s.RecipeId);
            */
        }
    }
}
