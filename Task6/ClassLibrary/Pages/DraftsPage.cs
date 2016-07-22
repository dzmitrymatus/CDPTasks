using OpenQA.Selenium;
using ClassLibrary.Infrastructure;

namespace ClassLibrary.Pages
{
    public class DraftsPage : BasePage
    {
        string Url = "https://e.mail.ru/messages/drafts/";

        public DraftsPage(IWebDriver driver) : base(driver) { }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public bool HasMail(string user, string subject)
        {
            string MailSelector = $"a[title='{user}'][data-subject='{subject}']";
            return driver.isElementPresent(By.CssSelector(MailSelector));
        }

        public NewMailPage OpenMail(string user, string subject)
        {
            string MailSelector = $"a[title='{user}'][data-subject='{subject}']";
            driver.FindElement(By.CssSelector(MailSelector)).Click();
            return new NewMailPage(this.driver);
        }
    }
}
