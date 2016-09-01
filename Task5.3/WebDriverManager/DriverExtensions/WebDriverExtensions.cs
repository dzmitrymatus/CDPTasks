using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverManager.DriverExtensions
{
    public static class WebDriverExtensions
    {
        public static bool isElementPresent(this IWebDriver driver, By locator)
        {
            try
            {
                driver.FindElement(locator);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
