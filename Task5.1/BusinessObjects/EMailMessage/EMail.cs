using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.EMailMessage
{
    public class EMail
    {
        private string emailAdress;
        private string message;
        private string subject;

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

    }
}
