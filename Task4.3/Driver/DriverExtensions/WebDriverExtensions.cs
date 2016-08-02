﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Infrastructure.DriverInstance;

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

        public static void CustomClick(this IWebElement element)
        {
            Driver.JavaScriptExecutor.ExecuteScript($"arguments[0].click()", element);
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