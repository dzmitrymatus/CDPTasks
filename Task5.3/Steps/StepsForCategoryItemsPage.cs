using PageObjects.Pages;
using TechTalk.SpecFlow;
using WebDriverManager.DriverInstance;

namespace Steps
{
    [Binding]
    public class StepsForCategoryItemsPage
    {
        CategoryItemsPage page = new CategoryItemsPage(Driver.Instance);

        [Given(@"I select '(.*)' checkbox in items container")]
        public void GivenISelectCheckboxInItemsContainer(string p0)
        {
            page.SelectFilterCategory(p0);
        }

        [Given(@"I click '(.*)' item in items container")]
        public void GivenIClickItemInItemsContainer(int p0)
        {
            page.SelectItem(p0);
        }
    }
}