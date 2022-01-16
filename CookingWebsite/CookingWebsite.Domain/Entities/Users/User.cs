using System;

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
            if (newValue.Length > 3)
            {
                throw new Exception();    
            }

            Name = newValue;
        }
        
        public void UpdateLogin(string newValue)
        {
            if (newValue.Length < 4)
            {
                throw new Exception();
            }

            Login = newValue;
        }
        
        public void UpdatePassword(string newValue)
        {
            if (newValue.Length < 8)
            {
                throw new Exception();
                
            }

            Password = newValue;
        }

        public void UpdateDescription(string newValue)
        {
            Description = newValue;
        }

    }
}
