using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Infrastructure.DriverExtensions;

namespace Pages
{
    public class InboxPage : BasePage
    {
        #region Private Members
        private const string Url = "https://e.mail.ru/messages/inbox/";
        private readonly By FirstMessage = By.CssSelector("[data-bem='b-datalist__item']");
        private readonly By DestinationElement = By.CssSelector("[data-mnemo='drafts']");

        [FindsBy(How = How.CssSelector, Using = "[data-name='compose']")]
        private IWebElement NewMessageButton;
        #endregion

        #region Constructors
        public InboxPage(IWebDriver driver) : base(driver) { }
        #endregion

        #region Public Methods
        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public NewMailPage NavigateToNewMailPage()
        {
            NewMessageButton.Click();
            return new NewMailPage(this.driver);
        }

        public void MoveMessageToDraftsFolder()
        {
            var message = driver.FindElement(FirstMessage);
            var destinationElement = driver.FindElement(DestinationElement);
            message.CustomDragAndDrop(destinationElement);
        }
        #endregion

    }
}
