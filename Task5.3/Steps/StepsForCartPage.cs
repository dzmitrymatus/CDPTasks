using NUnit.Framework;
using PageObjects.Pages;
using TechTalk.SpecFlow;
using WebDriverManager.DriverInstance;

namespace Steps
{
    [Binding]
    public class StepsForCartPage
    {
        CartPage page = new CartPage(Driver.Instance);

        [When(@"I navigate to the cart")]
        public void WhenINavigateToTheCart()
        {
            page.Navigate();
        }

        [Then(@"the cart sould be contain '(.*)' item")]
        public void ThenTheCartSouldBeContainItem(int p0)
        {
            Assert.That(page.GetElementsCount() == 1);
        }
    }
}
