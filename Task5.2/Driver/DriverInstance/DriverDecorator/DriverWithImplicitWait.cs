using OpenQA.Selenium;
using System;

namespace WebDriverManager.DriverInstance.DriverDecorator
{
    public class DriverWithImplicitWait : DriverDecorator
    {
        public DriverWithImplicitWait(IWebDriver driver) : base(driver)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }
    }
}
