using BusinessObjects.User;
using NUnit.Framework;
using Pages;
using WebDriverManager.DriverInstance;

namespace Steps
{
    public class StepsForLoginPage
    {
        LoginPage loginPage = new LoginPage(Driver.Instance);

        public void Login()
        {
            var user = UserFactory.CreateUserFromConfig();
            loginPage.Navigate();
            loginPage.Login(user.Login, user.Password);
            
        }

        public void AssertThatTheLoginIsSuccessful()
        {
            Assert.That(Driver.Instance.Url.Contains("https://e.mail.ru/messages/inbox/"), $"Bad login =(  {Driver.Instance.Url}");
        }
    }
}
