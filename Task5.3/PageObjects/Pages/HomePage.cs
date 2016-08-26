using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PageObjects.Base;

namespace PageObjects.Pages
{
    public class HomePage : BasePage
    {
        private const string Url = "http://www.ebay.com/";
        
        private string searchSelectListId = "gh-cat";

        [FindsBy(How = How.Id, Using = "gh-btn")]
        private IWebElement searchButton;

        public HomePage(IWebDriver driver):base(driver) { }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public void SelectCategoryInHeader(int categoryNumber)
        {
            SelectElement searchSelectList = new SelectElement(driver.FindElement(By.Id(searchSelectListId)));
            searchSelectList.SelectByIndex(categoryNumber);
        }

        public void ClickSearchButtonInHeader()
        {
            searchButton.Click();
        }
    }
}
