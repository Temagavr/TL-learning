using CookingWebsite.Domain.Repositories;
using CookingWebsite.Infrastructure.Foundation;
using System.Threading.Tasks;
using CookingWebsite.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace CookingWebsite.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CookingWebsiteDbContext _dbContext;

        private DbSet<User> _users => _dbContext.Set<User>();

        public UserRepository(CookingWebsiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUser(int userId)
        {
            return await _users.FirstOrDefaultAsync(u => u.Id == userId); 
        }

        public async Task<User> GetUser(string login)
        {
            return await _users.FirstOrDefaultAsync(u => u.Login == login);
        }

        public void Add(User user)
        {
            _dbContext.Add(user);
        }
        /*
        public void Save(User user)
        {
            _dbContext.SaveChangesAsync(user);
        }
        */

    }
}
