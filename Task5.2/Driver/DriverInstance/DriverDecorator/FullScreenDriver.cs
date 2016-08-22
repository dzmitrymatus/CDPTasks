using OpenQA.Selenium;

namespace WebDriverManager.DriverInstance.DriverDecorator
{
    public class FullScreenDriver : DriverDecorator
    {
        public FullScreenDriver(IWebDriver driver) : base(driver)
        {
            driver.Manage().Window.Maximize();
        }
    }
}
