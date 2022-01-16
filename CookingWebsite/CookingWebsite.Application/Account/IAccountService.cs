using CookingWebsite.Application.Account.UserDtos;
using CookingWebsite.Domain.Entities.Users;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Account
{
    public interface IAccountService
    {
        Task<bool> Registrate(RegistrationDto registrationDto);
        Task<bool> Login(LoginDto loginDto);
        void ChangeName(int userId, string newValue);
        void ChangeLogin(int userId, string newValue);
        void ChangePassword(int userId, string newValue);
        void ChangeDescription(int userId, string newValue);
    }
}
