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
    public class RecipeIngredientItemConfiguration : IEntityTypeConfiguration<RecipeIngredientItem>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredientItem> builder)
        {
            builder.ToTable(nameof(RecipeIngredientItem)).HasKey(t => t.Id);
            /*
            builder
                .HasOne<RecipeIngredient>()
                .WithOne()
                .HasForeignKey<RecipeIngredientItem>(i => i.RecipeIngredientId);
            */
        }
    }
}
