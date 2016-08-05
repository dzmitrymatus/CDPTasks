using Infrastructure.Browsers.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Infrastructure.Browsers
{
    public class Firefox : IBrowser
    {
        public IWebDriver Instance
        {
            get
            {
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                return new FirefoxDriver(service);
            }
        }

        public DesiredCapabilities Capabilities(bool sauceLabs, bool grid, string nodePlatform)
        {
            var capabilities = DesiredCapabilities.Firefox();

            if (sauceLabs)
            {

            }
            if (grid)
            {
                if (nodePlatform == "windows")
                {
                    capabilities.SetCapability("marionette", true);
                }
            }
            return capabilities;
        }
    }
}
