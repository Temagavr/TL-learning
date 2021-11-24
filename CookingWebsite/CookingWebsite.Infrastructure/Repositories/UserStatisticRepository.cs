using CookingWebsite.Domain.Entities.Users;
using CookingWebsite.Domain.Repositories;
using CookingWebsite.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CookingWebsite.Infrastructure.Repositories
{
    public class UserStatisticRepository : IUserStatisticRepository 
    {
        private readonly CookingWebsiteDbContext _dbContext;
        private DbSet<UserStatistic> _userStatistics => _dbContext.Set<UserStatistic>();
        public async Task<UserStatistic> GetById(int userId)
        {
            return await _userStatistics.FirstOrDefaultAsync(s => s.Id == userId);
        }

    }
}
