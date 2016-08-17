using System;

namespace BusinessObjects.EMailMessage
{
    public class EMail
    {
        #region Private members
        private string emailAdress;
        private string message;
        private string subject;
        #endregion

        #region Constructors
        public EMail()
        {
            emailAdress = "dzmitry.matus@gmail.com";
            message = "Hello World!";
            subject = $"Test {Guid.NewGuid()}";
        }

        public EMail(string emailAdress, string message, string subject)
        {
            this.emailAdress = emailAdress;
            this.message = message;
            this.subject = subject;
        }
        #endregion

        #region Public fields
        public string EMailAdress
        {
            get { return emailAdress; }
        }

        public string Message
        {
            get { return message; }
        }

        public string Subject
        {
            get { return subject; }
        }
        #endregion
    }
}
