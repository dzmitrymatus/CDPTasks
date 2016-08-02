using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace Infrastructure.DriverInstance
{
    public class Driver
    {
        private static Lazy<IWebDriver> driver = new Lazy<IWebDriver>(() => new FirefoxDriver());

        public static IWebDriver Instance
        {
            get { return driver.Value; }
        }

        public static IJavaScriptExecutor JavaScriptExecutor
        {
            get { return driver.Value as IJavaScriptExecutor; }
        }
    }
}
