using TechTalk.SpecFlow;

namespace Steps
{
    [Binding]
    public class StepsForCategoryPage
    {
        [Given(@"I select first link in categories list")]
        public void GivenISelectFirstLinkInCategoriesList()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
