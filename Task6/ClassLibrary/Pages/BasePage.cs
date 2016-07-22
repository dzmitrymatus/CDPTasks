using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ClassLibrary.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "a#PH_logoutLink")]
        protected IWebElement LogoutButton;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LogOut()
        {
            LogoutButton.Click();
        }
    }
}
