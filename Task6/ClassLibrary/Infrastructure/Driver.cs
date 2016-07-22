using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Infrastructure
{
    public class Driver
    {
        private static Lazy<IWebDriver> driver = new Lazy<IWebDriver>(() => new FirefoxDriver());

        public static IWebDriver Instance
        {
            get { return driver.Value; }
        }
    }
}
