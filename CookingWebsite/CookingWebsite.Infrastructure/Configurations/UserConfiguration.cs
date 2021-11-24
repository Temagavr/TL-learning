using CookingWebsite.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace CookingWebsite.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User)).HasKey(t => t.Id);

            builder
                .HasOne<UserStatistic>()
                .WithOne()
                .HasForeignKey<UserStatistic>(u => u.UserId);
        }
    }
}
