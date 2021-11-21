using CookingWebsite.Application.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.HomeModule
{
    [ApiController]
    [Route("api/home")]
    public class HomeController
    {
        private readonly AccountService _accountService;
        public HomeController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("registrate")]
        public async Task<bool> Registrate(UserRegistrationDto userRegistrationDto)
        {
            await _accountService.Registrate(userRegistrationDto.Map());
            return true;
        }
        
    }
}
