﻿using System;
using NUnit.Framework;
using Pages;
using Infrastructure.DriverInstance;
using System.Threading;

namespace Tests.Tests
{
    [TestFixture]
    [Author("Dzmitry Matus", "dzmitry_matus@epam.com")]
    public class MessageTest
    {        
        private const string Login = "automation.test";
        private const string Password = "502211qw-";
        private const string EMailAdress = "dzmitry.matus@gmail.com";
        private const string Message = "Hello World!";
        private readonly string Subject = $"Test {Guid.NewGuid()}";


        [TestCase]
        public void CreateNewMail()
        {
            var loginPage = new LoginPage(Driver.Instance);
            loginPage.Navigate();
            var inboxPage = loginPage.Login(Login, Password);
            Assert.That(Driver.Instance.Url.Contains("https://e.mail.ru/messages/inbox/"), $"Bad login =(  {Driver.Instance.Url}");

            //inboxPage.MoveMessageToDraftsFolder();

            var newMailPage = new NewMailPage(Driver.Instance);
            newMailPage.Navigate();
            newMailPage.FillTo(EMailAdress);
            newMailPage.FillSubject(Subject);
            newMailPage.FillMessage(Message);
            newMailPage.SaveAsDraft();
            var draftsPage = newMailPage.NavigateToDraftsPage();
            Assert.That(draftsPage.HasMail(EMailAdress, Subject), "Drafts folder don't contain mail");

            var mailPage = draftsPage.OpenMail(EMailAdress, Subject);
            var to = mailPage.GetTo();
            var subject = mailPage.GetSubject();
            var message = mailPage.GetMessage();
            Assert.That(to == EMailAdress && subject == Subject && message == Message, $"Message is not equal to the original message. 1: {to}, 2:{subject}, 3:{message}");

            mailPage.SendMail();
            draftsPage.Navigate();
            Assert.That(!draftsPage.HasMail(EMailAdress, Subject), "Message is not deleted from Drafts folder");

            var sentPage = new SentPage(Driver.Instance);
            sentPage.Navigate();
            var hasMail = sentPage.HasMail(EMailAdress, Subject);
            var mailTitle = sentPage.HoverOnMail(EMailAdress, Subject);
            Assert.That(hasMail && mailTitle == EMailAdress, "Sent folder don't contain Message");

            sentPage.DeleteMail(EMailAdress, Subject);
            sentPage.LogOut();
        }

    }
}
