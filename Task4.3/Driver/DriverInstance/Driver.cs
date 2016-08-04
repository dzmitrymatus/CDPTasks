using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using Infrastructure.Browsers.Interface;
using Infrastructure.Browsers;
using Infrastructure.Browsers.Factory;
using OpenQA.Selenium.Remote;

namespace Infrastructure.DriverInstance
{
    public class Driver
    {
        private static Lazy<RemoteWebDriver> driver = new Lazy<RemoteWebDriver>(() => CreateDriver());

        public static RemoteWebDriver Instance
        {
            get { return driver.Value; }
        }

        public static IJavaScriptExecutor JavaScriptExecutor
        {
            get { return driver.Value as IJavaScriptExecutor; }
        }

        public static RemoteWebDriver CreateDriver()
        {
            var browser = BrowserFactory.GetBrowser(ConfigurationManager.AppSettings["Browser"]);
            var useSauceLabs = bool.Parse(ConfigurationManager.AppSettings["UseSauceLabs"]);
            var useSeleniumGrid = bool.Parse(ConfigurationManager.AppSettings["UseSeleniumGrid"]);

            var capabilities = browser.Capabilities(useSauceLabs, useSeleniumGrid);

            if (useSauceLabs)
            {
                var user = ConfigurationManager.AppSettings["SauceLabsUser"];
                var key = ConfigurationManager.AppSettings["SauceLabsKey"];
                capabilities.SetCapability("username", user);
                capabilities.SetCapability("accessKey", key);
                return new RemoteWebDriver(new Uri($"http://ondemand.saucelabs.com:80/wd/hub"), capabilities);
            }

            if (useSeleniumGrid)
            {
                var url = new Uri(ConfigurationManager.AppSettings["HubUrl"]);
                return new RemoteWebDriver(url, capabilities);
            }
            return (RemoteWebDriver)browser.Instance;
        }
    }
}
