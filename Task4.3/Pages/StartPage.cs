using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Infrastructure.DriverExtensions;

namespace Pages
{
    public class StartPage : BasePage
    {
        #region Private Members
        private const string Url = "https://mail.ru/";

        [FindsBy(How = How.Id, Using = "mailbox__login")]
        private IWebElement LoginInput;
        [FindsBy(How = How.Id, Using = "mailbox__password")]
        private IWebElement PasswordInput;
        [FindsBy(How = How.Id, Using = "mailbox__auth__button")]
        private IWebElement LoginButton;
        [FindsBy(How = How.Id, Using = "logo")]
        private IWebElement Logo;
        #endregion

        #region Constructors
        public StartPage(IWebDriver driver) : base(driver) { }
        #endregion

        #region Public Methods
        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public InboxPage Login(string login, string password)
        {
            FillLogin(login);
            FillPassword(password);
            LoginButton.CustomClick();
            return new InboxPage(this.driver);
        }

        public void FillLogin(string login)
        {
            LoginInput.Clear();
            LoginInput.SendKeys(login);
        }

        public void FillPassword(string password)
        {
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
        }
        #endregion
    }
}
