using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using Infrastructure.DriverInstance;

namespace Pages
{
    public class NewMailPage : BasePage
    {
        #region Private Members
        private const string Url = "https://e.mail.ru/compose";

        [FindsBy(How = How.XPath, Using = @"//div[@class='compose__header__content']/div[2]/div[2]")]
        private IWebElement ToInputText;
        [FindsBy(How = How.XPath, Using = @"//input[@name='Subject']")]
        private IWebElement SubjectInput;
        [FindsBy(How = How.XPath, Using = @"//td[contains(@class,'mceIframeContainer')]/iframe")]
        private IWebElement MessageInputFrame;
        [FindsBy(How = How.Id, Using = "tinymce")]
        private IWebElement MessageInput;
        [FindsBy(How = How.CssSelector, Using = @"div[data-group='save-more']")]
        private IWebElement SaveDropdown;
        [FindsBy(How = How.CssSelector, Using = @"a[data-name='saveDraft']")]
        private IWebElement SaveAsDraftButton;
        [FindsBy(How = How.CssSelector, Using = @"div[data-name='send']")]
        private IWebElement SendButton;
        [FindsBy(How = How.CssSelector, Using = "div[data-mnemo='saveStatus'] a")]
        private IWebElement DraftsLink;
        [FindsBy(How = How.CssSelector, Using = "input[name='draft_msg']")]
        private IWebElement IdInput;
        [FindsBy(How = How.CssSelector, Using = "div.message-sent__title")]
        private IWebElement SendStatusTextBox;
        #endregion

        #region Constructors
        public NewMailPage(IWebDriver driver) : base(driver) { }
        #endregion

        #region Public Methods
        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public void FillTo(string emailAdress)
        {
            Actions action = new Actions(this.driver);
            action.MoveToElement(ToInputText, 15, 15);
            action.Click();
            action.SendKeys(emailAdress);
            action.Perform();
            action.Click().Perform();
        }

        public string GetTo()
        {
            return ToInputText.Text;
        }

        public void FillSubject(string subject)
        {
            Driver.JavaScriptExecutor.ExecuteScript($"arguments[0].value = '{subject}'", SubjectInput);
        }

        public string GetSubject()
        {
            return SubjectInput.GetAttribute("value");
        }

        public void FillMessage(string message)
        {
            this.driver.SwitchTo().Frame(MessageInputFrame);
            MessageInput.Clear();
            MessageInput.SendKeys(message);
            driver.SwitchTo().DefaultContent();
        }

        public string GetMessage()
        {
            this.driver.SwitchTo().Frame(MessageInputFrame);
            var message = MessageInput.Text;
            driver.SwitchTo().DefaultContent();
            return message;
        }

        public void SaveAsDraft()
        {
            SaveDropdown.Click();
            SaveAsDraftButton.Click();
        }

        public void SendMail()
        {
            SendButton.Click();
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(15));
            wait.Until(x => SendStatusTextBox.Text != "Ваше письмо отправлено.Перейти во Входящие");           
        }

        public DraftsPage NavigateToDraftsPage()
        {
            DraftsLink.Click();
            return new DraftsPage(this.driver);
        }
        #endregion
    }
}
