using System;
using System.Threading.Tasks;
using CookingWebsite.Application.Dtos.UserDtos;
using CookingWebsite.Domain;
using CookingWebsite.Domain.Entities.Users;
using CookingWebsite.Domain.Repositories;

namespace CookingWebsite.Application.Account
{
    public class AccountService
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
            var user = await _userRepostitory.GetUser(registrationDto.Login);
            if (user != null)
                return false;

            user = new User(
                registrationDto.Login,
                registrationDto.Password,
                registrationDto.Name,
                userInfo: ""
                );
            _userRepostitory.Add(user);

            Console.WriteLine($"{user.Login}, {user.Password}, {user.Name}");

            return true;
        }

        public async Task<bool> Login (LoginDto loginDto)
        {
            var user = await _userRepostitory.GetUser(loginDto.Login);
            if (user != null)
                return false;
            else if (loginDto.Password == user.Password)
            {
                return true;
            }

            return false;
        }

        public async Task Edit (EditUserDto editUserDto)
        {
            

            await _unitOfWork.Commit();
            
        }
    }
}
