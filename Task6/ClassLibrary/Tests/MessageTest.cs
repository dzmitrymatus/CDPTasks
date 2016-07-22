using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using ClassLibrary.Pages;
using System.Diagnostics;
using ClassLibrary.Infrastructure;

namespace ClassLibrary.Tests
{
    [TestFixture]
    public class MessageTest
    {        
        string Login = "automation.test";
        string Password = "502211qw-";
        string EMailAdress = "dzmitry.matus@gmail.com";
        string Subject;
        string Message = "Hello World!";

        [SetUp]
        public void SetUp()
        {
            Subject = $"Test {Guid.NewGuid()}";
        }

        [TestCase]
        public void CreateNewMail()
        {
            var startPage = new StartPage(Driver.Instance);
            startPage.Navigate();
            startPage.FillLogin(Login);
            startPage.FillPassword(Password);
            var inboxPage = startPage.Login();
            Assert.That(Driver.Instance.Url == "https://e.mail.ru/messages/inbox/?back=1", "Bad login =(");

            var newMailPage = inboxPage.NavigateToNewMailPage();
            newMailPage.FillTo(EMailAdress);
            newMailPage.FillSubject(Subject);
            newMailPage.FillMessage(Message);
            newMailPage.SaveAsDraft();
            var draftsPage = newMailPage.NavigateToDraftsPage();
            Assert.That(draftsPage.HasMail(EMailAdress, Subject),"Drafts folder don't contain mail");

            var mailPage = draftsPage.OpenMail(EMailAdress, Subject);
            var to = mailPage.GetTo();
            var subject = mailPage.GetSubject();
            var message = mailPage.GetMessage();
            Assert.That(to == EMailAdress && subject == Subject && message == Message, $"Message is not equal to the original message");

            mailPage.SendMail();
            draftsPage.Navigate();
            Assert.That(!draftsPage.HasMail(EMailAdress, Subject), "Message is not deleted from Drafts folder");

            var sentPage = new SentPage(Driver.Instance);
            sentPage.Navigate();
            Assert.That(sentPage.HasMail(EMailAdress, Subject), "Sent folder don't contain Message");

            sentPage.DeleteMail(EMailAdress, Subject);
            sentPage.LogOut();
        }

    }
}
