using CookingWebsite.Application.Account.UserDtos;
using CookingWebsite.Domain.Entities.Users;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Account
{
    public interface IAccountService
    {
        Task<bool> Registrate(RegistrationDto registrationDto);
        Task<bool> Login(LoginDto loginDto);
        Task<User> GetUserInfo(int userId);
        Task<bool> ChangeName(int userId, string newValue);
        Task<bool> ChangeLogin(int userId, string newValue);
        Task<bool> ChangePassword(int userId, string newValue);
        Task<bool> ChangeDescription(int userId, string newValue);
    }
}
