using PageObjects.Pages;
using TechTalk.SpecFlow;
using WebDriverManager.DriverInstance;

namespace Steps
{
    [Binding]
    public class StepsForCategoryPage
    {
        CategoryPage page = new CategoryPage(Driver.Instance);

        [Given(@"I select first link in categories list")]
        public void GivenISelectFirstLinkInCategoriesList()
        {
            page.SelectCategory(1);
        }
    }
}
