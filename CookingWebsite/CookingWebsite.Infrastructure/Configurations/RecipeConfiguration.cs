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
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable(nameof(Recipe)).HasKey(t => t.Id);

            /*
            builder
                .HasOne<RecipeIngredient>()
                .WithMany()
                .HasForeignKey(i => i.RecipeId);
            */
        }
    }
}
