using OpenQA.Selenium;

namespace ClassLibrary.Infrastructure
{
    public static class WebDriverExtensions
    {
        public static bool isElementPresent(this IWebDriver driver, By locator)
        {
            try
            {
                driver.FindElement(locator);
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
            return true;
        }
    }
}
