using CookingWebsite.Application.Account;
using CookingWebsite.Domain;
using CookingWebsite.Domain.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                await Authenticate(userRegistrationDto.Login);
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
                await Authenticate(userLoginDto.Login);
                return true;
            }
            else
                return false;

        }

        [HttpGet("details")]
        public async Task<UserInfoDto> GetUserInfo([FromQuery] string username)
        {
            var user = await _userRepository.GetByLogin(username);

            return user.Map();
        }

        [HttpGet("get-user")]
        public void GetCookieUser()
        {
            var test = User.Identity.Name;
        }
        
        private async Task Authenticate(string username)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, username)
            };

            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(
                claims,
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType
            );

            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        
    }
}
