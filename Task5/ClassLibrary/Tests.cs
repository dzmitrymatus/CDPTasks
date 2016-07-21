using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace ClassLibrary
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;
        string Url = "https://mail.ru/";
        string DraftsUrl = "https://e.mail.ru/messages/drafts/";
        string SentUrl = "https://e.mail.ru/messages/sent/";
        string Login = "automation.test";
        string Password = "502211qw-";
        string LoginInputId = "mailbox__login";
        string PasswordInputClass = "mailbox__password";
        string LoginButtonCssSelector = "#mailbox__auth__button";
        string NewLetterCssSelector = ".b-toolbar__btn.js-shortcut";
        string ToInputSelector = "textarea[data-original-name='To']";
        string ComposeInputSelector = "input.compose__header__field";
        string IFrameCssSelector = "td.mceIframeContainer.mceFirst.mceLast iframe";
        string TextInputId = "tinymce";
        string SaveDropdownSelector = @"div[data-group='save-more']";
        string SaveButtonSelector = "a[data-text = 'Сохранить черновик']";
        string DraftsLinkSelector = "div[data-mnemo = 'saveStatus'] a";
        string MailSelector = @"a[title='dzmitry.matus@gmail.com'][data-subject='Test']";
        string ToSelector = "div.compose__header__field__box";
        string SendButtonSelector = "div[data-name='send']";
        string LogOutSelector = "a#PH_logoutLink";


        string Adress = "dzmitry.matus@gmail.com";
        string Title = "Test";
        string Message = "Hello World!";


        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        [TestCase]
        public void CreateNewMail()
        {

            //login
            LoginInSystem();

            //create new message
            driver.FindElement(By.CssSelector(NewLetterCssSelector)).Click();

            //fill inputs
            var toInput = driver.FindElement(By.CssSelector(ToInputSelector));
            var composeInput = driver.FindElement(By.CssSelector(ComposeInputSelector));
        
            toInput.Clear();
            toInput.SendKeys(Adress);
            composeInput.Clear();
            composeInput.SendKeys(Title);

            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector(IFrameCssSelector)));
            var textInput = driver.FindElement(By.Id(TextInputId));

            textInput.Clear();
            textInput.SendKeys(Message);

            driver.SwitchTo().DefaultContent();


            //save message
            driver.FindElement(By.CssSelector(SaveDropdownSelector)).Click();
            var saveButton = driver.FindElement(By.CssSelector(SaveButtonSelector));
            saveButton.Click();

            //navigate to drafts and verify that message is
            driver.FindElement(By.CssSelector(DraftsLinkSelector)).Click();
            Assert.That(driver.isElementPresent(By.CssSelector(MailSelector)));

            //open mail
            var item = driver.FindElement(By.CssSelector(MailSelector));
            item.Click();


            //check mail
            toInput = driver.FindElement(By.CssSelector(ToSelector));
            composeInput = driver.FindElements(By.CssSelector(ToSelector))[3].FindElement(By.CssSelector("input"));

            var draftTo = toInput.Text;
            var draftCompose = composeInput.GetAttribute("value");

            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector(IFrameCssSelector)));
            textInput = driver.FindElement(By.Id(TextInputId));
            var draftMessage = textInput.Text;

            driver.SwitchTo().DefaultContent();

            Assert.That(draftTo == Adress && draftCompose == Title && draftMessage == Message, $"{draftTo} : {draftCompose} : {draftMessage}");

            //send mail
            driver.FindElement(By.CssSelector(SendButtonSelector)).Click();
            driver.Navigate().GoToUrl(DraftsUrl);
            Assert.That(!driver.isElementPresent(By.CssSelector(MailSelector)));

            //check that mail has in sentfolder
            driver.Navigate().GoToUrl(SentUrl);
            Assert.That(driver.isElementPresent(By.CssSelector(MailSelector)));


            //delete mail
            driver.FindElement(By.CssSelector(MailSelector)).Click();
            Actions builder = new Actions(driver);
            builder.SendKeys(Keys.Delete).Perform();

            //logout
            driver.FindElement(By.CssSelector(LogOutSelector)).Click();
        }


        private void LoginInSystem()
        {
            driver.Navigate().GoToUrl(Url);
            var loginInput = driver.FindElement(By.Id(LoginInputId));
            var passwordInput = driver.FindElement(By.ClassName(PasswordInputClass));

            loginInput.Clear();
            loginInput.SendKeys(Login);
            passwordInput.Clear();
            passwordInput.SendKeys(Password);
            driver.FindElement(By.CssSelector(LoginButtonCssSelector)).Click();
        }
    }
}
