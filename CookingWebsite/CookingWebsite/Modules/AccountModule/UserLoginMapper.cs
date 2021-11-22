using CookingWebsite.Application.Dtos.UserDtos;

namespace CookingWebsite.Modules.AccountModule
{
    public static class UserLoginMapper
    {
        public static LoginDto Map(this UserLoginDto userLoginDto)
        {
            var loginDto = new LoginDto();

            loginDto.Login = userLoginDto.Login;
            loginDto.Password = userLoginDto.Password;

            return loginDto;
        }
    }
}
