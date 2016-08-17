using OpenQA.Selenium;
using WebDriverManager.DriverExtensions;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Pages
{
    public class SentPage : BasePage
    {
        #region Private Members
        private const string Url = "https://e.mail.ru/messages/sent/";

        [FindsBy(How = How.CssSelector, Using = "[data-name='remove']")]
        private IWebElement DeleteButton;
        [FindsBy(How = How.CssSelector, Using = ".b-tooltip.b-tooltip_nocorner.b-tooltip_animate.b-tooltip_tc")]
        private IWebElement Message;
        private readonly By CheckboxSelector = By.CssSelector(".js-item-checkbox.b-datalist__item__cbx");

        private const string MailSelectorTemplate = "a[title='{0}'][data-subject='{1}']";
        private Func<string, string, string> MailSelector = (user, subject) => String.Format(MailSelectorTemplate, user, subject);
        #endregion

        #region Constructors
        public SentPage(IWebDriver driver) : base(driver) { }
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

        public string HoverOnMail(string user, string subject)
        {
            var mail = driver.FindElement(By.CssSelector(MailSelector.Invoke(user, subject)));
            ((IHasInputDevices)driver).Mouse.MouseMove(((ILocatable)mail).Coordinates, 15, 15);
            try
            {
                var text = Message.Text;
                return text;
            }
            catch
            {
                var text = mail.GetAttribute("title");
                return text;
            }
        }

        public void DeleteMail(string user, string subject)
        {
            driver.FindElement(By.CssSelector(MailSelector.Invoke(user, subject))).FindElement(CheckboxSelector).Click();
            DeleteButton.Click();
        }
        #endregion
    }
}
