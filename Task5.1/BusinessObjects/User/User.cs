using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.User
{
    public class User
    {
        private readonly string login;
        private readonly string password;

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public string Login
        {
            get {return login; }
        }

        public string Password
        {
            get { return password; }
        }
    }
}
