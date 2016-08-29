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

        [Given(@"I navigate to the cart page")]
        [When(@"I navigate to the cart page")]
        public void WhenINavigateToTheCart()
        {
            page.Navigate();
        }

        [Then(@"the cart sould be contain '(.*)' item")]
        public void ThenTheCartSouldBeContainItem(int p0)
        {
            Assert.That(page.GetElementsCount() == p0);
        }

        [Given(@"I clear cart")]
        public void GivenIClearCart()
        {
            page.ClearCart();
        }

    }
}
