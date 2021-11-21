using CookingWebsite.Domain.Entities.Users;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Repositories
{
    public interface IUserStatisticRepository
    {
        Task<UserStatistic> GetStatistic(int userId);
    }
}
