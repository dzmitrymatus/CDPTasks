using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObjects.Base;
using System;

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
        private IWebElement selectLotsCheckbox;
        [FindsBy(How = How.ClassName, Using = "submit-btn")]
        private IWebElement submitButton;

        private readonly By productSelector = By.CssSelector("li.sresult.lvresult");
        private readonly By productTitleSelector = By.CssSelector("h3.lvtitle");
        private readonly Func<string, By> filterCategorySelector = new Func<string, By>(x => By.CssSelector($"a[title='{x}']"));


        public CategoryItemsPage(IWebDriver driver) : base(driver) { }


        public void SelectFilterCategory(string title)
        {
            filterCategoriesContainer.FindElement(filterCategorySelector(title)).Click();
        }

        public void SelectItem(int number)
        {

            itemsContainer.FindElements(productSelector)[number - 1].FindElement(productTitleSelector).Click();
        }

        public void ShowLots()
        {
            showOnlyLink.Click();
            selectLotsCheckbox.Click();
            submitButton.Click();
        }

    }
}
