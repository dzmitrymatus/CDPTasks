namespace ConfigurationManager
{
    public static class Configuration
    {
        #region Private members
        private static string useSauceLabsKey = "UseSauceLabs";
        private static string sauceLabsUserKey = "SauceLabsUser";
        private static string sauceLabsKeyKey = "SauceLabsKey";
        private static string useSeleniumGridKey = "UseSeleniumGrid";
        private static string hubUrlKey = "HubUrl";
        private static string nodePlatformKey = "NodePlatform";
        private static string browserKey = "Browser";
        private static string loginKey = "Login";
        private static string passwordKey = "Password";
        #endregion

        #region Public fields
        public static bool UseSauceLabs
        {
            get
            {
                var value = System.Configuration.ConfigurationManager.AppSettings[useSauceLabsKey];
                bool result;
                if (bool.TryParse(value, out result))
                {
                    return result;
                }
                return false;
            }
        }

        public static string SauceLabsUser
        {
            get { return System.Configuration.ConfigurationManager.AppSettings[sauceLabsUserKey]; }
        }

        public static string SauceLabsKey
        {
            get { return System.Configuration.ConfigurationManager.AppSettings[sauceLabsKeyKey]; }
        }

        public static bool UseSeleniumGrid
        {
            get
            {
                var value = System.Configuration.ConfigurationManager.AppSettings[useSeleniumGridKey];
                bool result;
                if (bool.TryParse(value, out result))
                {
                    return result;
                }
                return false;
            }
        }

        public static string HubUrl
        {
            get { return System.Configuration.ConfigurationManager.AppSettings[hubUrlKey]; }
        }

        public static string NodePlatform
        {
            get { return System.Configuration.ConfigurationManager.AppSettings[nodePlatformKey]; }
        }

        public static string Browser
        {
            get { return System.Configuration.ConfigurationManager.AppSettings[browserKey]; }
        }

        public static string Login
        {
            get { return System.Configuration.ConfigurationManager.AppSettings[loginKey]; }
        }

        public static string Password
        {
            get { return System.Configuration.ConfigurationManager.AppSettings[passwordKey]; }
        }
        #endregion
    }
}
