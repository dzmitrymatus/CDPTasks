using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObjects.Base;

namespace PageObjects.Pages
{
    public class ItemPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "isCartBtn_btn")]
        private IWebElement addToCartButton;

        public ItemPage(IWebDriver driver):base(driver) { }

        public void AddToCart()
        {
            addToCartButton.Click();
        }
    }
}
