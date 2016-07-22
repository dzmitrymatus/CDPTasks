using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ClassLibrary.Pages
{
    public class StartPage : BasePage
    {
        string Url = "https://mail.ru/";

        [FindsBy(How = How.Id, Using = "mailbox__login")]
        protected IWebElement LoginInput;
        [FindsBy(How = How.ClassName, Using = "mailbox__password")]
        protected IWebElement PasswordInput;
        [FindsBy(How = How.CssSelector, Using = "#mailbox__auth__button")]
        protected IWebElement LoginButton;

        public StartPage(IWebDriver driver) : base(driver) { }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
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

        public InboxPage Login()
        {
            LoginButton.Click();
            return new InboxPage(this.driver);
        }
    }
}
