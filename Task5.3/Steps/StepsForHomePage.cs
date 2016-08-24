using TechTalk.SpecFlow;

namespace Steps
{
    [Binding]
    public class StepsForHomePage
    {
        [Given(@"I open www\.ebay\.com page")]
        public void GivenIOpenWww_Ebay_ComPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I select first item in search dropdown list")]
        public void GivenISelectFirstItemInSearchDropdownList()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I click search button in the header")]
        public void GivenIClickSearchButtonInTheHeader()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
