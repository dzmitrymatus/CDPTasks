using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;

namespace ClassLibrary.Pages
{
    public class NewMailPage : BasePage
    {
        string Url = "https://e.mail.ru/compose";

        [FindsBy(How = How.CssSelector, Using = "textarea[data-original-name='To']")]
        protected IWebElement ToInput;
        [FindsBy(How = How.CssSelector, Using = "div.compose__header__row_to div.compose__header__field__box")]
        protected IWebElement ToInputText;
        [FindsBy(How = How.CssSelector, Using = "div.compose__header__field__box input.compose__header__field")]
        protected IWebElement SubjectInput;
        [FindsBy(How = How.CssSelector, Using = "td.mceIframeContainer.mceFirst.mceLast iframe")]
        protected IWebElement MessageInputFrame;
        [FindsBy(How = How.Id, Using = "tinymce")]
        protected IWebElement MessageInput;
        [FindsBy(How = How.CssSelector, Using = @"div[data-group='save-more']")]
        protected IWebElement SaveDropdown;
        [FindsBy(How = How.CssSelector, Using = @"a[data-text = 'Сохранить черновик']")]
        protected IWebElement SaveAsDraftButton;
        [FindsBy(How = How.CssSelector, Using = @"div[data-name='send']")]
        protected IWebElement SendButton;
        [FindsBy(How = How.CssSelector, Using = "div[data-mnemo = 'saveStatus'] a")]
        protected IWebElement DraftsLink;
        [FindsBy(How = How.CssSelector, Using = "input[name= 'draft_msg']")]
        protected IWebElement IdInput;
        [FindsBy(How = How.CssSelector, Using = "div.message-sent__title")]
        protected IWebElement SendStatusTextBox;


        public NewMailPage(IWebDriver driver) : base(driver) { }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public void FillTo(string emailAdress)
        {
            ToInput.Clear();
            ToInput.Click();
            ToInput.SendKeys(emailAdress);
        }

        public string GetTo()
        {
            return ToInputText.Text;
        }

        public void FillSubject(string subject)
        {
            SubjectInput.Clear();
            SubjectInput.SendKeys(subject);
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

    }
}
