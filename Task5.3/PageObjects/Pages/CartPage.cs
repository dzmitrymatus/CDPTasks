using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObjects.Base;

namespace PageObjects.Pages
{
    public class CartPage : BasePage
    {
        private const string Url = "http://cart.payments.ebay.com/sc/view";
        
        [FindsBy(How = How.Id, Using = "ShopCart")]
        private IWebElement elementsContainer;

        public CartPage(IWebDriver driver):base(driver) { }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public int GetElementsCount()
        {  
            return elementsContainer.FindElements(By.CssSelector("div.c-std > div")).Count;
        }

        public void ClearCart()
        {
            foreach(var item in elementsContainer.FindElements(By.CssSelector("div.c-std > div")))
            {
                item.FindElement(By.LinkText("Удалить")).Click();
            }
        }
    }
}
