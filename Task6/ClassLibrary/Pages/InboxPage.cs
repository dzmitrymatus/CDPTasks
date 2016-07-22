using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Diagnostics;

namespace ClassLibrary.Pages
{
    public class InboxPage : BasePage
    {
        string Url = "https://e.mail.ru/messages/inbox/";

        [FindsBy(How = How.CssSelector, Using = "a[data-name='compose']")]
        protected IWebElement NewMessageButton;

        public InboxPage(IWebDriver driver) : base(driver) { }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public NewMailPage NavigateToNewMailPage()
        {
            NewMessageButton.Click();
            return new NewMailPage(this.driver);
        }
    }
}
