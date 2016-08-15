using Infrastructure.Browsers.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace Infrastructure.Browsers
{
    public class InternetExplorer : IBrowser
    {
        private const string Platform = "WIN10";

        public IWebDriver Instance
        {
            get { return new InternetExplorerDriver(); }
        }

        public DesiredCapabilities Capabilities(bool sauceLabs, bool grid, string nodePlatform)
        {
                DesiredCapabilities caps = DesiredCapabilities.InternetExplorer();
                caps.SetCapability("platform", Platform);
                return caps;
        }
    }
}
