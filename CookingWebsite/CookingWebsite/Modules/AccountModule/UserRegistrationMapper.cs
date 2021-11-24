using CookingWebsite.Application.Account.UserDtos;

namespace CookingWebsite.Modules.AccountModule
{
    public static class UserRegistrationMapper
    {
        public static RegistrationDto Map(this UserRegistrationDto userRegistrationDto)
        {
            var registrationDto = new RegistrationDto();

            registrationDto.Login = userRegistrationDto.Login;
            registrationDto.Password = userRegistrationDto.Password;
            registrationDto.Name = userRegistrationDto.Name;

            return registrationDto;
        }
    }
}
