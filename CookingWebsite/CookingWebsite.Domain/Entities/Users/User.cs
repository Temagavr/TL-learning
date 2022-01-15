namespace CookingWebsite.Domain.Entities.Users
{
    public class User
    {
        public int Id { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public User(
            string login,
            string password,
            string name,
            string description
            )
        {
            Login = login;
            Password = password;
            Name = name;
            Description = description;
        }

        protected User() { }

        public void UpdateName(string newValue)
        {
            Name = newValue;
        }
        
        public void UpdateLogin(string newValue)
        {
            Login = newValue;
        }
        
        public void UpdatePassword(string newValue)
        {
            Password = newValue;
        }

        public void UpdateDescription(string newValue)
        {
            Description = newValue;
        }

    }
}
