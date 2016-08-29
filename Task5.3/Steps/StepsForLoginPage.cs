using PageObjects.Pages;
using TechTalk.SpecFlow;
using WebDriverManager.DriverInstance;

namespace Steps
{
    [Binding]
    public class StepsForLoginPage
    {
        LoginPage page = new LoginPage(Driver.Instance);

        [Given(@"I open login page")]
        public void GivenIOpenLoginPage()
        {
            page.Navigate();
        }

        [Given(@"I login in system with login:""(.*)"" and password: ""(.*)""")]
        public void GivenILoginInSystemWithLoginAndPassword(string p0, string p1)
        {
            page.Login(p0, p1);
        }


    }
}
