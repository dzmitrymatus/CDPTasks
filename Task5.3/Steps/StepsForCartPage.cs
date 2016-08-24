using TechTalk.SpecFlow;

namespace Steps
{
    [Binding]
    public class StepsForCartPage
    {
        [When(@"I navigate to the cart")]
        public void WhenINavigateToTheCart()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the cart sould be contain '(.*)' item")]
        public void ThenTheCartSouldBeContainItem(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
