using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObjects.Base;
using System.Threading;

namespace PageObjects.Pages
{
    public class CategoryItemsPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".pnl-b.frmt")]
        private IWebElement filterCategoriesContainer;
        [FindsBy(How = How.Id, Using = "ListViewInner")]
        private IWebElement itemsContainer;
        
        public CategoryItemsPage(IWebDriver driver):base(driver) { }


        public void SelectFilterCategory(string title)
        {
            filterCategoriesContainer.FindElement(By.CssSelector($"a[title='{title}']")).Click();
        }

        public void SelectItem(int number)
        {

            itemsContainer.FindElements(By.TagName("li"))[number-1].Click();
        }
    }
}
