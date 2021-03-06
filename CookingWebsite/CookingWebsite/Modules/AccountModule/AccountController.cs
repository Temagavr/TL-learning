using CookingWebsite.Application.Account;
using CookingWebsite.Domain;
using CookingWebsite.Domain.Entities.Users;
using CookingWebsite.Domain.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.AccountModule
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IAccountService accountService, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _accountService = accountService;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("registrate")]
        public async Task<bool> Registrate(UserRegistrationDto userRegistrationDto)
        {
            var registrateResult = await _accountService.Registrate(userRegistrationDto.Map());

            if (registrateResult)
            {
                await _unitOfWork.Commit();

                var user = await _userRepository.GetByLogin(userRegistrationDto.Login);
                await Authenticate(user);
                return true;
            }   
            else
                return false;
        }
        
        [HttpPost("login")]
        public async Task<bool> Login(UserLoginDto userLoginDto)
        {
            var loginResult = await _accountService.Login(userLoginDto.Map());
            if (loginResult)
            {
                var user = await _userRepository.GetByLogin(userLoginDto.Login);
                await Authenticate(user);
                return true;
            }
            else
                return false;

        }

        [HttpGet("authorized-user")]
        public async Task<AuthorizedUserDto> AuthorizedUser()
        {
            var authorizedUser = new AuthorizedUserDto();

            if (User.FindFirstValue(Claims.UserId) != null)
            {
                authorizedUser.Id = Convert.ToInt32(User.FindFirstValue(Claims.UserId));
                User user = await _userRepository.GetById(authorizedUser.Id);
                authorizedUser.Name = user.Name;
                authorizedUser.Login = user.Login;
            } 
            else
            {
                authorizedUser = null;
            }

            return authorizedUser;
        }

        [HttpGet("logout")]
        public void UserLogout()
        {
            Logout();
        }
        
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(Claims.UserId, user.Id.ToString()),
                new Claim(Claims.Username, user.Login),
                new Claim(Claims.Name, user.Name)
            };

            // создаем объект ClaimsIdentity
            ClaimsIdentity claimIdentity = new ClaimsIdentity(
                claims,
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType
            );

            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));
        }

        public async void Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
