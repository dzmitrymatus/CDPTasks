using NUnit.Framework;
using Steps;

namespace Tests.Tests
{
    [TestFixture]
    [Author("Dzmitry Matus", "dzmitry_matus@epam.com")]
    public class MessageTest: TestBase
    {        

        [TestCase]
        public void CreateNewMail()
        {
            var loginPage = new StepsForLoginPage();
            loginPage.Login();
            loginPage.AssertThatTheLoginIsSuccessful();

            var newMailPage = new StepsForNewMailPage();
            newMailPage.CreateNewMail();
            newMailPage.SaveTheMailAsADraft();
            newMailPage.NavigateToDraftsPage();

            var draftsPage = new StepsForDraftsPage();
            draftsPage.AssertThatDraftsFolderContainMessage();
            draftsPage.OpenMail();

            var mailPage = new StepsForNewMailPage();
            mailPage.VerifyTheDraftContent();
            mailPage.SendMail();

            draftsPage = new StepsForDraftsPage();
            draftsPage.Navigate();
            draftsPage.VerifyThatTheMailDisappearedFromDraftsFolder();

            var sentPage = new StepsForSentPage();
            sentPage.Navigate();
            sentPage.VerifyThatTheMailIsInSentFolder();

            sentPage.DeleteMail();
            sentPage.LogOut();

        }

    }
}
