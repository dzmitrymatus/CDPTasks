using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace WebDriverManager.DriverInstance
{
    public class Driver
    {
        #region Private members 
        private static volatile IWebDriver driver;
        private static readonly object syncObject = new object();
        #endregion

        #region Public fields
        public static IWebDriver Instance
        {
            get
            {
                if (driver == null)
                {
                    lock (syncObject)
                    {
                        if (driver == null)
                        {
                            driver = CreateDriver();
                        }
                    }
                }
                return driver;
            }
        }
        #endregion

        #region Public methods
        public static void CloseDriver()
        {
            driver.Dispose();
            driver = null;
        }
        #endregion

        #region Private methods
        private static IWebDriver CreateDriver()
        {
            return new ChromeDriver();
        }
        #endregion
    }
}
