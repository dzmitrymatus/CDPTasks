using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ClassLibrary
{
    public static class Extensions
    {
        public static bool isElementPresent(this IWebDriver driver, By locator)
        {
            try
            {
                driver.FindElement(locator);
            }
            catch(NoSuchElementException ex)
            {
                return false;
            }
            return true;
        }
    }
}
