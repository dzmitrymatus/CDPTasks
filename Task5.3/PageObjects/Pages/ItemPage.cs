using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObjects.Base;

namespace PageObjects.Pages
{
    public class ItemPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "isCartBtn_btn")]
        private IWebElement addToCartButton;
        [FindsBy(How = How.Id, Using = "contShoppingBtn")]
        private IWebElement continueShoppingButton;
        
        public ItemPage(IWebDriver driver):base(driver) { }

        public void AddToCart()
        {
            addToCartButton.Click();
        }

        public void ContinueShopping()
        {
            continueShoppingButton.Click();
        }
    }
}
