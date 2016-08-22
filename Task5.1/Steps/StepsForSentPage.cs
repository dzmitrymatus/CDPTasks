using BusinessObjects.EMailMessage;
using NUnit.Framework;
using Pages;
using WebDriverManager.DriverInstance;

namespace Steps
{
    public class StepsForSentPage
    {
        SentPage sentPage = new SentPage(Driver.Instance);
        EMail email = EMail.Instance;

        public void Navigate()
        {
            sentPage.Navigate();
        }

        public void VerifyThatTheMailIsInSentFolder()
        {
            var hasMail = sentPage.HasMail(email.EMailAdress, email.Subject);
            Assert.That(hasMail, "Sent folder don't contain Message");
        }

        public void DeleteMail()
        {
            sentPage.DeleteMail(email.EMailAdress, email.Subject);
        }

        public void LogOut()
        {
            sentPage.LogOut();
        }

    }
}
