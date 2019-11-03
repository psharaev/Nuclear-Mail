using MimeKit;
using Nuclear_Mail.Models;
using Nuclear_Mail.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclear_Mail.ViewModels
{
    public static class MailManager
    {
        public static List<MailBox> GetMailBoxes() => Data.Instance.MailBoxes;

        public static void CreateMailBox(in string login, in string password)
        {
            MailBox mailBox = new MailBox(login, password);
            CreateMailBox(mailBox);
        }

        public static void SendMessage(MailBox mailBox, MimeMessage mimeMessage) => MailController.SendMessage(mailBox, mimeMessage);

        public static void CreateMailBox(in MailBox mailBox)
        {
            Data.Instance.CreateMailBox(mailBox);
        }
    }
}
