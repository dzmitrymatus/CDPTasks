using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObjects.Base;

namespace PageObjects.Pages
{
    public class LoginPage : BasePage
    {
        private const string Url = "https://signin.ebay.com";

        [FindsBy(How = How.Id, Using = "formDiv")]
        private IWebElement loginForm;
        [FindsBy(How = How.Id, Using = "csi")]
        private IWebElement stayInSystemCheckBox;
        [FindsBy(How = How.Id, Using = "sgnBt")]
        private IWebElement loginButton;

        private readonly By inputSelector = By.TagName("input");
        private const string isCheckedAttributeName = "aria-checked";

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public void Login(string login, string password)
        {
            loginForm.FindElements(inputSelector)[1].SendKeys(login);
            loginForm.FindElements(inputSelector)[3].SendKeys(password);
            if (stayInSystemCheckBox.GetAttribute(isCheckedAttributeName) == "true")
            {
                stayInSystemCheckBox.Click();
            }
            loginButton.Click();
        }
    }
}
