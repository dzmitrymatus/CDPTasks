using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class BasePage
    {
        #region Protected Members
        protected readonly IWebDriver driver;

        [FindsBy(How = How.Id, Using = "PH_logoutLink")]
        protected IWebElement LogoutButton;
        #endregion

        #region Constructors
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
        #endregion

        #region Public Methods
        public void LogOut()
        {
            LogoutButton.Click();
        }
        #endregion
    }
}
