using CookingWebsite.Domain.Entities.Users;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
        Task<User> GetUser(string login);
        void Add(User user);
        //void Save(User user);
    }
}
