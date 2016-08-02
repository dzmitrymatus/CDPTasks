using Infrastructure.Browsers.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System.Configuration;

namespace Infrastructure.Browsers
{
    public class Firefox : IBrowser
    {
        public IWebDriver Instance
        {
            get { return new FirefoxDriver(); }
        }

        public DesiredCapabilities Capabilities
        {
            get
            {
                var browser = DesiredCapabilities.Firefox();
                var user = ConfigurationManager.AppSettings["SauceLabsUser"];
                var key = ConfigurationManager.AppSettings["SauceLabsKey"];
                browser.SetCapability("username", user);
                browser.SetCapability("accessKey", key);
                return browser;
            }
        }
    }
}
