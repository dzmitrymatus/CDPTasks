namespace BusinessObjects.User
{
    public class User
    {
        #region Private members
        private readonly string login;
        private readonly string password;
        #endregion

        #region Constructors
        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        #endregion

        #region Public methods
        public string Login
        {
            get { return login; }
        }

        public string Password
        {
            get { return password; }
        }
        #endregion
    }
}
