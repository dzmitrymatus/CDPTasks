using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObjects.Base;

namespace PageObjects.Pages
{
    public class CategoryPage : BasePage
    {
        [FindsBy(How = How.ClassName, Using = "navigation-list")]
        private IWebElement navigationList;

        public CategoryPage(IWebDriver driver):base(driver) { }

        public void SelectCategory(int categoryNumber)
        {
            navigationList.FindElement(By.CssSelector(".navigation-list")).FindElements(By.TagName("li"))[categoryNumber - 1].Click();
        }
    }
}
