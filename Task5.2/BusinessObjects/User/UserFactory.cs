using System;
using ConfigurationManager;

namespace BusinessObjects.User
{
    public static class UserFactory
    {
        public static User CreateUserFromConfig()
        {
            if(string.IsNullOrEmpty(Configuration.Login) || string.IsNullOrEmpty(Configuration.Password))
            {
                throw new Exception("Config file don't contain user data");
            }

            return new User(Configuration.Login, Configuration.Password);
        }
    }
}
