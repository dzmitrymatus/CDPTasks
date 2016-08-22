using BusinessObjects.EMailMessage;
using NUnit.Framework;
using Pages;
using WebDriverManager.DriverInstance;

namespace Steps
{
    public class StepsForNewMailPage
    {
        EMail email = EMail.Instance;
        NewMailPage newMailPage = new NewMailPage(Driver.Instance);

        public void CreateNewMail()
        {
            newMailPage.Navigate();
            newMailPage.FillTo(email.EMailAdress);
            newMailPage.FillSubject(email.Subject);
            newMailPage.FillMessage(email.Message);
        }

        public void SaveTheMailAsADraft()
        {
            newMailPage.SaveAsDraft();
        }

        public void VerifyTheDraftContent()
        {
            var to = newMailPage.GetTo();
            var subject = newMailPage.GetSubject();
            var message = newMailPage.GetMessage();
            Assert.That(to == email.EMailAdress && subject == email.Subject && message == email.Message, $"Message is not equal to the original message. 1: {to}, 2:{subject}, 3:{message}");
        }

        public void SendMail()
        {
            newMailPage.SendMail();
        }

        public void NavigateToDraftsPage()
        {
            newMailPage.NavigateToDraftsPage();
        }

    }
}
