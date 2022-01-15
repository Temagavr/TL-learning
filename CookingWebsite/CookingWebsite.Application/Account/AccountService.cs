using System;
using System.Threading.Tasks;
using CookingWebsite.Application.Account.UserDtos;
using CookingWebsite.Domain;
using CookingWebsite.Domain.Entities.Users;
using CookingWebsite.Domain.Repositories;

namespace CookingWebsite.Application.Account
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepostitory;

        private readonly IUnitOfWork _unitOfWork;

        public AccountService( IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepostitory = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Registrate (RegistrationDto registrationDto)
        {
            var user = await _userRepostitory.GetByLogin(registrationDto.Login);
            if (user != null && !ValidateRegistration(registrationDto))
                return false;

            user = new User(
                registrationDto.Login,
                registrationDto.Password,
                registrationDto.Name,
                description: ""
                );
            _userRepostitory.Add(user);

            Console.WriteLine($"{user.Login}, {user.Password}, {user.Name}");

            return true;
        }

        public async Task<bool> Login (LoginDto loginDto)
        {
            var user = await _userRepostitory.GetByLogin(loginDto.Login);
            Console.WriteLine($"{loginDto.Login}, {loginDto.Password}");
            if (user == null)
                return false;
            else if (loginDto.Password == user.Password)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> ChangeName(int userId, string newValue)
        {
            User user = await _userRepostitory.GetById(userId);

            if (user == null)
                return false;

            user.UpdateName(newValue);
            return true;
        }

        public async Task<bool> ChangeLogin(int userId, string newValue)
        {
            User user = await _userRepostitory.GetById(userId);

            if (user == null)
                return false;

            user.UpdateLogin(newValue);
            return true;
        }

        public async Task<bool> ChangePassword(int userId, string newValue)
        {
            User user = await _userRepostitory.GetById(userId);

            if (user == null)
                return false;

            user.UpdatePassword(newValue);
            return true;
        }

        public async Task<bool> ChangeDescription(int userId, string newValue)
        {
            User user = await _userRepostitory.GetById(userId);

            if (user == null)
                return false;

            user.UpdateDescription(newValue);
            return true;
        }

        public async Task<User> GetUserInfo(int userId)
        {
            User user = await _userRepostitory.GetById(userId);

            return user;
        }

        private bool ValidateRegistration(RegistrationDto registrationDto)
        {
            if (registrationDto.Name == "")
                return false;

            if (registrationDto.Login == "")
                return false;

            if (registrationDto.Password == "")
                return false;

            if (registrationDto.Password != registrationDto.RepeatPassword)
                return false;

            return true;
        }
    }
}
