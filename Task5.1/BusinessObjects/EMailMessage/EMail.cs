using System;

namespace BusinessObjects.EMailMessage
{
    public class EMail
    {
        #region Private members
        static Lazy<EMail> instance = new Lazy<EMail>(() => new EMail());

        private string emailAdress;
        private string subject;
        private string message;
        #endregion

        #region Constructors
        EMail()
        {
            emailAdress = "dzmitry.matus@gmail.com";
            subject = $"Test {Guid.NewGuid()}";
            message = "Hello World!";
        }
        #endregion

        #region Public fields
        public static EMail Instance
        {
            get { return instance.Value; }
        }
        

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
