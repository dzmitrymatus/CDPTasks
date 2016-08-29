using PageObjects.Pages;
using TechTalk.SpecFlow;
using WebDriverManager.DriverInstance;

namespace Steps
{
    [Binding]
    public class StepsForItemPage
    {
        ItemPage page = new ItemPage(Driver.Instance);

        [When(@"I click Add to cart button")]
        public void WhenIClickButton()
        {
            page.AddToCart();
        }

        [When(@"I click continue shopping button")]
        public void WhenIBackToItemsPage()
        {
            page.ContinueShopping();
        }

    }
}
