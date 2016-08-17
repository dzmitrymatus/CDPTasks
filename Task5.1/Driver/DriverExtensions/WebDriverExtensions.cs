using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Internal;

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
            catch (NoSuchElementException ex)
            {
                return false;
            }
            return true;
        }
    }

    public static class WebElementCustomExtensions
    {
        public static void CustomDragAndDrop(this IWebElement element, IWebElement destinationElement)
        {
            IWebDriver driver = GetWebDriver(element);
            Actions actions = new Actions(driver);
            actions.ClickAndHold(element).MoveToElement(destinationElement).Release(destinationElement).Perform();
        }

        public static void CustomClickWithWait(this IWebElement element, int maxWaitTime = 90)
        {
            IWebDriver driver = GetWebDriver(element);
            var url = driver.Url;

            (driver as IJavaScriptExecutor).ExecuteScript($"arguments[0].click()", element);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWaitTime));
            wait.Until((x) => x.Url != url);
            wait.Until((x) => (driver as IJavaScriptExecutor).ExecuteScript("return document.readyState").ToString().Equals("complete"));

        }

        public static void CustomHideElement(this IWebElement element)
        {
            IWebDriver driver = GetWebDriver(element);
            var display = (driver as IJavaScriptExecutor).ExecuteScript($"return arguments[0].style.display", element) as string;

            if (display != "none")
            {
                (driver as IJavaScriptExecutor).ExecuteScript($"arguments[0].style.display = 'none' ", element);
            }
        }

        public static void CustomShowElement(this IWebElement element)
        {
            IWebDriver driver = GetWebDriver(element);
            var display = (driver as IJavaScriptExecutor).ExecuteScript($"return arguments[0].style.display", element) as string;

            if (display != "")
            {
                (driver as IJavaScriptExecutor).ExecuteScript($"arguments[0].style.display = '' ", element);
            }
        }

        private static IWebDriver GetWebDriver(IWebElement element)
        {
            IWebDriver driver;
            try
            {
                driver = (element as RemoteWebElement).WrappedDriver;
            }
            catch
            {
                driver = ((element as IWrapsElement).WrappedElement as RemoteWebElement).WrappedDriver;
            }
            return driver;
        }

    }


}
