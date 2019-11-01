using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Nuclear_Mail.Models.Protocols;

namespace Nuclear_Mail.Models
{
    [Serializable]
    public class MailBox
    {
        public string email_address = "";
        public string password = "";

        public bool usePop3 = false;
        public bool useImap = false;
        public bool useSmtp = false;

        public POP Pop3 = null;
        public IMAP Imap = null;
        public SMTP Smtp = null;

        public MailBox()
        {

        }
    }
}
