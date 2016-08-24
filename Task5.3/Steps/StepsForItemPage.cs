using TechTalk.SpecFlow;

namespace Steps
{
    [Binding]
    public class StepsForItemPage
    {
        [When(@"I click ""(.*)"" button")]
        public void WhenIClickButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the successful message should be shown on the page")]
        public void ThenTheSuccessfulMessageShouldBeShownOnThePage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
