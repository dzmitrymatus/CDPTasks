using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Infrastructure.DriverExtensions;
using Infrastructure.DriverInstance;
using OpenQA.Selenium.Support.UI;
using System;

namespace Pages
{
    public class LoginPage : BasePage
    {
        #region Private Members
        private const string Url = "https://e.mail.ru/login";

        [FindsBy(How = How.CssSelector, Using = "input[name='Login']")]
        private IWebElement LoginInput;
        [FindsBy(How = How.CssSelector, Using = "input[name='Password']")]
        private IWebElement PasswordInput;
        [FindsBy(How = How.CssSelector, Using = "button[type='submit'][tabindex='1008']")]
        private IWebElement LoginButton;
        [FindsBy(How = How.Id, Using = "logo")]
        private IWebElement Logo;
        [FindsBy(How = How.Id, Using = "alien")]
        private IWebElement SaveCheckbox;
        #endregion

        #region Constructors
        public LoginPage(IWebDriver driver) : base(driver) { }
        #endregion

        #region Public Methods
        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public InboxPage Login(string login, string password, bool saveCredentials = false)
        {
            FillLogin(login);
            FillPassword(password);
            var saveCredentialsChecboxValue = bool.Parse(SaveCheckbox.GetAttribute("checked"));
            if ((saveCredentials && !saveCredentialsChecboxValue) || (!saveCredentials && saveCredentialsChecboxValue))
            {
                    SaveCheckbox.Click();
            }
            LoginButton.CustomClickWithWait();

            return new InboxPage(this.driver);
        }

        public void FillLogin(string login)
        {
            LoginInput.Clear();
            Driver.JavaScriptExecutor.ExecuteScript($"arguments[0].value = '{login}'", LoginInput);
        }

        public void FillPassword(string password)
        {
            PasswordInput.Clear();
            Driver.JavaScriptExecutor.ExecuteScript($"arguments[0].value = '{password}'", PasswordInput);
        }
        #endregion
    }
}
