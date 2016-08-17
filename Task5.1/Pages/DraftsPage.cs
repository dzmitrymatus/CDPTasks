using OpenQA.Selenium;
using WebDriverManager.DriverExtensions;
using System;

namespace Pages
{
    public class DraftsPage : BasePage
    {
        #region Private Members
        private const string Url = "https://e.mail.ru/messages/drafts/";
        private const string MailSelectorTemplate = "a[title='{0}'][data-subject='{1}']";
        private Func<string, string, string> MailSelector = (user, subject) => String.Format(MailSelectorTemplate, user, subject);
        #endregion

        #region Constructors
        public DraftsPage(IWebDriver driver) : base(driver) { }
        #endregion

        #region Public Methods
        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public bool HasMail(string user, string subject)
        {
            return driver.isElementPresent(By.CssSelector(MailSelector.Invoke(user, subject)));
        }

        public NewMailPage OpenMail(string user, string subject)
        {
            driver.FindElement(By.CssSelector(MailSelector.Invoke(user, subject))).Click();
            return new NewMailPage(this.driver);
        }
        #endregion

    }
}
