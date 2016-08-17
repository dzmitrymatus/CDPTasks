using NUnit.Framework;
using Pages;
using WebDriverManager.DriverInstance;
using BusinessObjects.User;
using BusinessObjects.EMailMessage;

namespace Tests.Tests
{
    [TestFixture]
    [Author("Dzmitry Matus", "dzmitry_matus@epam.com")]
    public class MessageTest: TestBase
    {        

        [TestCase]
        public void CreateNewMail()
        {
            var user = UserFactory.CreateUserFromConfig();
            var email = new EMail();

            var loginPage = new LoginPage(Driver.Instance);
            loginPage.Navigate();

            var inboxPage = loginPage.Login(user.Login, user.Password);
            Assert.That(Driver.Instance.Url.Contains("https://e.mail.ru/messages/inbox/"), $"Bad login =(  {Driver.Instance.Url}");

            var newMailPage = new NewMailPage(Driver.Instance);
            newMailPage.Navigate();
            newMailPage.FillTo(email.EMailAdress);
            newMailPage.FillSubject(email.Subject);
            newMailPage.FillMessage(email.Message);
            newMailPage.SaveAsDraft();
            var draftsPage = newMailPage.NavigateToDraftsPage();
            Assert.That(draftsPage.HasMail(email.EMailAdress, email.Subject), "Drafts folder don't contain mail");

            var mailPage = draftsPage.OpenMail(email.EMailAdress, email.Subject);
            var to = mailPage.GetTo();
            var subject = mailPage.GetSubject();
            var message = mailPage.GetMessage();
            Assert.That(to == email.EMailAdress && subject == email.Subject && message == email.Message, $"Message is not equal to the original message. 1: {to}, 2:{subject}, 3:{message}");

            mailPage.SendMail();
            draftsPage.Navigate();
            Assert.That(!draftsPage.HasMail(email.EMailAdress, email.Subject), "Message is not deleted from Drafts folder");

            var sentPage = new SentPage(Driver.Instance);
            sentPage.Navigate();
            var hasMail = sentPage.HasMail(email.EMailAdress, email.Subject);
            Assert.That(hasMail, "Sent folder don't contain Message");

            sentPage.DeleteMail(email.EMailAdress, email.Subject);
            sentPage.LogOut();
        }

    }
}
