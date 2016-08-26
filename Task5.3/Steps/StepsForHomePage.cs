using PageObjects.Pages;
using TechTalk.SpecFlow;
using WebDriverManager.DriverInstance;

namespace Steps
{
    [Binding]
    public class StepsForHomePage
    {
        HomePage page = new HomePage(Driver.Instance);
        [Given(@"I open www\.ebay\.com page")]
        public void GivenIOpenWww_Ebay_ComPage()
        {
            page.Navigate();
        }

        [Given(@"I select first item in search dropdown list")]
        public void GivenISelectFirstItemInSearchDropdownList()
        {
            page.SelectCategoryInHeader(1);
        }

        [Given(@"I click search button in the header")]
        public void GivenIClickSearchButtonInTheHeader()
        {
            page.ClickSearchButtonInHeader();
        }
    }
}
