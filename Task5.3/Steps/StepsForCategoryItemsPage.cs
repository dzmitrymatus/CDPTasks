using TechTalk.SpecFlow;

namespace Steps
{
    [Binding]
    public class StepsForCategoryItemsPage
    {
        [Given(@"I select '(.*)' checkbox in items container")]
        public void GivenISelectCheckboxInItemsContainer(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I click '(.*)' item in items container")]
        public void GivenIClickItemInItemsContainer(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}