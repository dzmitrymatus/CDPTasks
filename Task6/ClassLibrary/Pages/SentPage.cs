using OpenQA.Selenium;
using ClassLibrary.Infrastructure;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;

namespace ClassLibrary.Pages
{
    public class SentPage : BasePage
    {
        string Url = "https://e.mail.ru/messages/sent/";

        [FindsBy(How = How.CssSelector, Using = "div.compose__header__field__box")]
        protected IWebElement DeleteButton;

        public SentPage(IWebDriver driver) : base(driver) { }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public bool HasMail(string user, string subject)
        {
            string MailSelector = $"a[title='{user}'][data-subject='{subject}']";
            return driver.isElementPresent(By.CssSelector(MailSelector));
        }

        public void DeleteMail(string user, string subject)
        {
            string MailSelector = $"a[title='{user}'][data-subject='{subject}']";
            driver.FindElement(By.CssSelector(MailSelector)).FindElement(By.CssSelector(".js-item-checkbox.b-datalist__item__cbx")).Click();
            Actions builder = new Actions(driver);
            builder.SendKeys(Keys.Delete).Perform();
        }
    }
}
