using WebDriverManager.Browsers.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace WebDriverManager.Browsers
{
    public class Chrome : IBrowser
    {
        public IWebDriver Instance
        {
            get { return new ChromeDriver(); }
        }

        public DesiredCapabilities Capabilities(bool sauceLabs, bool grid, string nodePlatform)
        {
                return DesiredCapabilities.Chrome();
        }
    }
}
