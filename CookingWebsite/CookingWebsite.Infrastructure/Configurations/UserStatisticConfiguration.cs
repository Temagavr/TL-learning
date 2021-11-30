using CookingWebsite.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CookingWebsite.Infrastructure.Configurations
{
    public class UserStatisticConfiguration : IEntityTypeConfiguration<UserStatistic>
    {
        public void Configure(EntityTypeBuilder<UserStatistic> builder)
        {
            builder.ToTable(nameof(UserStatistic)).HasKey(t => t.Id);
        }
    }
}
