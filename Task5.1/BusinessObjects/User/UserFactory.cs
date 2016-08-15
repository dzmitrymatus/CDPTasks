using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.User
{
    public static class UserFactory
    {
        public static User CreateUserFromConfig()
        {
            var login = ConfigurationManager.AppSettings["Login"];
            var password = ConfigurationManager.AppSettings["Password"];
            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Config file don't contain user data");
            }

            return new User(login, password);
        }
    }
}
