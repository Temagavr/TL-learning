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
    public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.ToTable(nameof(RecipeIngredient)).HasKey(t => t.Id);
            /*
            builder
                .HasOne<Recipe>()
                .WithOne()
                .HasForeignKey<RecipeIngredient>(i => i.RecipeId);
            */
        }
    }
}
