using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriver.Browsers.Interface
{
    public interface IBrowser
    {
        IWebDriver Instance { get; }
        DesiredCapabilities Capabilities(bool sauceLabs = false, bool grid = false, string nodePlatform = "windows");
    }
}
