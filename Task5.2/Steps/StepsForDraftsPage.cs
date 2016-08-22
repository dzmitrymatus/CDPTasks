using BusinessObjects.EMailMessage;
using NUnit.Framework;
using Pages;
using WebDriverManager.DriverInstance;

namespace Steps
{
    public class StepsForDraftsPage
    {
        DraftsPage draftsPage = new DraftsPage(Driver.Instance);
        EMail email = EMail.Instance;

        public void Navigate()
        {
            draftsPage.Navigate();
        }

        public void AssertThatDraftsFolderContainMessage()
        {
            Assert.That(draftsPage.HasMail(email.EMailAdress, email.Subject), "Drafts folder don't contain mail");
        }

        public void OpenMail()
        {
            draftsPage.OpenMail(email.EMailAdress, email.Subject);
        }

        public void VerifyThatTheMailDisappearedFromDraftsFolder()
        {
            Assert.That(!draftsPage.HasMail(email.EMailAdress, email.Subject), "Message is not deleted from Drafts folder");
        }
    }
}
