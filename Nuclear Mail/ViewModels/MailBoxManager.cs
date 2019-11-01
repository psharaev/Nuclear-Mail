using Nuclear_Mail.Models;
using Nuclear_Mail.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclear_Mail.ViewModels
{
    public static class MailBoxManager
    {
        public static void CreateMailBox(in string login,in string password)
        {
            MailBox mailBox = new MailBox
            {
                email_address = login,
                password = password,
                useImap = true,
                useSmtp = true,
                Imap = new Models.Protocols.IMAP(),
                Smtp = new Models.Protocols.SMTP()
            };
            CreateMailBox(mailBox);
        }

        public static void CreateMailBox(in MailBox mailBox)
        {
            Data.Instance.CreateMailBox(mailBox);
        }
    }
}
