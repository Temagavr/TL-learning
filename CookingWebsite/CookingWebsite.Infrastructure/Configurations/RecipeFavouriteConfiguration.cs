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
    public class RecipeFavouriteConfiguration : IEntityTypeConfiguration<RecipeFavourite>
    {
        public void Configure(EntityTypeBuilder<RecipeFavourite> builder)
        {
            builder.ToTable(nameof(RecipeFavourite)).HasKey(t => t.Id);

            builder.HasIndex(x => new { x.UserId, x.RecipeId }).IsUnique();
        }
    }
}
