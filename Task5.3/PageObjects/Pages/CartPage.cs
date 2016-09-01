using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObjects.Base;
using System;
using WebDriverManager.DriverExtensions;

namespace PageObjects.Pages
{
    public class CartPage : BasePage
    {
        private const string Url = "http://cart.payments.ebay.com/sc/view";
        private readonly By deleteButton = By.LinkText("Удалить");
        private readonly By productSelector = By.CssSelector("div.c-std > div");
        private readonly By successfulMessageSelector = By.CssSelector(".msgWrapper .sm-co.sm-su");

        [FindsBy(How = How.Id, Using = "ShopCart")]
        private IWebElement elementsContainer;


        public CartPage(IWebDriver driver) : base(driver) { }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public int GetElementsCount()
        {
            if (driver.isElementPresent(productSelector))
            {
                return elementsContainer.FindElements(productSelector).Count;
            }
            return 0;
        }

        public void ClearCart()
        {
            var itemsCount = GetElementsCount();
            for (int i = 0; i < itemsCount; i++)
            {
                elementsContainer.FindElement(productSelector).FindElement(deleteButton).Click();
            }
        }

        public bool HasSuccessfulMessage()
        {
            return driver.isElementPresent(successfulMessageSelector);
        }
    }
}
