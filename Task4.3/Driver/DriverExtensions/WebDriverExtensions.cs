using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Infrastructure.DriverInstance;
using System;
using OpenQA.Selenium.Remote;

namespace Infrastructure.DriverExtensions
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
            Actions actions = new Actions(Driver.Instance);
            actions.ClickAndHold(element).MoveToElement(destinationElement).Release(destinationElement).Perform();
        }

        public static void CustomClickWithWait(this IWebElement element, int maxWaitTime = 90)
        {
            var url = Driver.Instance.Url;

            Driver.JavaScriptExecutor.ExecuteScript($"arguments[0].click()", element);
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(maxWaitTime));
            wait.Until((x) => x.Url != url);
            wait.Until((x) => Driver.JavaScriptExecutor.ExecuteScript("return document.readyState").ToString().Equals("complete"));

        }

        public static void CustomHideElement(this IWebElement element)
        {
            var display = Driver.JavaScriptExecutor.ExecuteScript($"return arguments[0].style.display", element) as string;

            if (display != "none")
            {
                Driver.JavaScriptExecutor.ExecuteScript($"arguments[0].style.display = 'none' ", element);
            }
        }

        public static void CustomShowElement(this IWebElement element)
        {
            var display = Driver.JavaScriptExecutor.ExecuteScript($"return arguments[0].style.display", element) as string;

            if (display != "")
            {
                Driver.JavaScriptExecutor.ExecuteScript($"arguments[0].style.display = '' ", element);
            }
        }

    }


}
