namespace CookingWebsite.Application.Account.UserDtos
{
    public class EditUserDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
