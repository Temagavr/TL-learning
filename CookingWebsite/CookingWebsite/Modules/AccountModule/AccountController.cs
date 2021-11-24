using CookingWebsite.Application.Account;
using CookingWebsite.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.AccountModule
{
    [ApiController]
    [Route("api/account")]
    public class AccountController
    {
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IAccountService accountService, IUnitOfWork unitOfWork)
        {
            _accountService = accountService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("registrate")]
        public async Task<bool> Registrate(UserRegistrationDto userRegistrationDto)
        {
            Console.WriteLine("Fetch Post to registrate");
            var registrateResult = await _accountService.Registrate(userRegistrationDto.Map());

            Console.WriteLine(registrateResult);

            if (registrateResult)
            {
                await _unitOfWork.Commit();
                return true;
            }   
            else
                return false;
        }
        
        [HttpPost("login")]
        public async Task<bool> Login(UserLoginDto userLoginDto)
        {
            return await _accountService.Login(userLoginDto.Map());
        }
        
    }
}
