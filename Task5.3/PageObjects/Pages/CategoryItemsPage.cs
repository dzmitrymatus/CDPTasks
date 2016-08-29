using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObjects.Base;

namespace PageObjects.Pages
{
    public class CategoryItemsPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".pnl-b.frmt")]
        private IWebElement filterCategoriesContainer;
        [FindsBy(How = How.Id, Using = "ListViewInner")]
        private IWebElement itemsContainer;
        [FindsBy(How = How.Id, Using = "LH_ShowOnly")]
        private IWebElement showOnlyLink;
        [FindsBy(How = How.Id, Using = "LH_Lots_1")]
        private IWebElement showLotsCheckbox;
        [FindsBy(How = How.ClassName, Using = "submit-btn")]
        private IWebElement submitButton;
        
        public CategoryItemsPage(IWebDriver driver) : base(driver) { }


        public void SelectFilterCategory(string title)
        {
            filterCategoriesContainer.FindElement(By.CssSelector($"a[title='{title}']")).Click();
        }

        public void SelectItem(int number)
        {

            itemsContainer.FindElements(By.CssSelector("li.sresult.lvresult"))[number - 1].FindElement(By.CssSelector("h3.lvtitle")).Click();
        }

        public void ShowLots()
        {
            showOnlyLink.Click();
            showLotsCheckbox.Click();
            submitButton.Click();
        }

    }
}
