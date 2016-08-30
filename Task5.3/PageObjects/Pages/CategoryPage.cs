using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObjects.Base;

namespace PageObjects.Pages
{
    public class CategoryPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".navigation-list .navigation-list")]
        private IWebElement navigationList;

        private readonly By categorySelector = By.TagName("li");

        public CategoryPage(IWebDriver driver):base(driver) { }

        public void SelectCategory(int categoryNumber)
        {
            navigationList.FindElements(categorySelector)[categoryNumber - 1].Click();
        }
    }
}
