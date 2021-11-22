using CookingWebsite.Domain.Entities.Users;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<User> GetByLogin(string login);
        void Add(User user);
        //void Save(User user);
    }
}
