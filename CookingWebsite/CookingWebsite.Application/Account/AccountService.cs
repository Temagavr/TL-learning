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

            return true;
        }

        public async Task<bool> Login (LoginDto loginDto)
        {
            var user = await _userRepostitory.GetByLogin(loginDto.Login);
            if (user == null)
                return false;
            else if (loginDto.Password == user.Password)
            {
                return true;
            }

            return false;
        }

        public async void ChangeName(int userId, string newValue)
        {
            User user = await _userRepostitory.GetById(userId);

            if (user == null)
                throw new Exception($"Cannot change name. User by id:{userId} not found");

            user.UpdateName(newValue);
        }

        public async void ChangeLogin(int userId, string newValue)
        {
            User user = await _userRepostitory.GetById(userId);

            if (user == null)
                throw new Exception($"Cannot change login. User by id:{userId} not found");

            user.UpdateLogin(newValue);
        }

        public async void ChangePassword(int userId, string newValue)
        {
            User user = await _userRepostitory.GetById(userId);

            if (user == null)
                throw new Exception($"Cannot change password. User by id:{userId} not found");

            user.UpdatePassword(newValue);
        }

        public async void ChangeDescription(int userId, string newValue)
        {
            User user = await _userRepostitory.GetById(userId);

            if (user == null)
                throw new Exception($"Cannot change description. User by id:{userId} not found");

            user.UpdateDescription(newValue);
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
