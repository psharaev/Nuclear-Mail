using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nuclear_Mail.Models.Protocols;

namespace Nuclear_Mail.Models
{
    public class MailBox
    {
        public string email_address = "";
        public string password = "";

        public bool usePop3 = false;
        public bool useImap = false;
        public bool useSmtp = false;

        public POP3 Pop3;
        public IMAP Imap;
        public SMTP Smtp;
    }
}
