using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjects.Base
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
    }
}
