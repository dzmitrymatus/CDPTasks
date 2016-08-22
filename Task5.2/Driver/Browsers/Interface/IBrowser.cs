using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace WebDriverManager.Browsers.Interface
{
    public interface IBrowser
    {
        IWebDriver Instance { get; }
        DesiredCapabilities Capabilities(bool sauceLabs = false, bool grid = false, string nodePlatform = "windows");
    }
}
