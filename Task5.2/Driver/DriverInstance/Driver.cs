﻿using OpenQA.Selenium;
using System;
using WebDriverManager.Browsers.Factory;
using OpenQA.Selenium.Remote;
using ConfigurationManager;
using WebDriverManager.DriverInstance.DriverDecorator;

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
                            driver = new DriverWithImplicitWait(new FullScreenDriver(CreateDriver())) as IWebDriver;
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
            var browser = BrowserFactory.GetBrowser(Configuration.Browser);
            var useSauceLabs = Configuration.UseSauceLabs;
            var useSeleniumGrid = Configuration.UseSeleniumGrid;
            var nodePlatform = Configuration.NodePlatform;

            var capabilities = browser.Capabilities(useSauceLabs, useSeleniumGrid, nodePlatform);

            if (useSauceLabs)
            {
                var user = Configuration.SauceLabsUser;
                var key = Configuration.SauceLabsKey;
                capabilities.SetCapability("username", user);
                capabilities.SetCapability("accessKey", key);
                return new RemoteWebDriver(new Uri($"http://ondemand.saucelabs.com:80/wd/hub"), capabilities);
            }

            if (useSeleniumGrid)
            {
                var url = new Uri(Configuration.HubUrl);
                return new RemoteWebDriver(url, capabilities);
            }
            return browser.Instance;
        }
        #endregion
    }
}
