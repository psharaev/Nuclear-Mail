using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using MailKit.Net;
using Nuclear_Mail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nuclear_Mail.Models.Patterns;
using MimeKit;
using MailKit;
using System.Diagnostics;

namespace Nuclear_Mail.Models
{
    public static class MailController
    {
        private static Dictionary<MailBox, ImapClient> ImapClients = new Dictionary<MailBox, ImapClient>();
        private static Dictionary<MailBox, Pop3Client> Pop3Clients = new Dictionary<MailBox, Pop3Client>();
        private static Dictionary<MailBox, SmtpClient> SmtpClients = new Dictionary<MailBox, SmtpClient>();

        public static void CreateClient(MailBox mailBox)
        {
            if (mailBox == null) throw new ArgumentNullException();

            if (mailBox.useImap)
            {
                if (mailBox.Imap == null) throw new ArgumentNullException();

                ImapClients.Add(mailBox, new ImapClient());
                var client = ImapClients[mailBox];
                if (mailBox.Imap.TrustAnySSL) client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(mailBox.Imap.InboxServerName,
                    mailBox.Imap.useSsl ? mailBox.Imap.SslPort : mailBox.Imap.Port,
                    mailBox.Imap.useSsl);
                client.Authenticate(mailBox.email_address, mailBox.password);
            }
            else if (mailBox.usePop3)
            {
                if (mailBox.Pop3 == null) throw new ArgumentNullException();

                Pop3Clients.Add(mailBox, new Pop3Client());
                var client = Pop3Clients[mailBox];
                if (mailBox.Pop3.TrustAnySSL) client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(mailBox.Pop3.InboxServerName,
                    mailBox.Pop3.useSsl ? mailBox.Pop3.SslPort : mailBox.Pop3.Port,
                    mailBox.Pop3.useSsl);
                client.Authenticate(mailBox.email_address, mailBox.password);
            }

            if (mailBox.useSmtp)
            {
                if (mailBox.Smtp == null) throw new ArgumentNullException();

                SmtpClients.Add(mailBox, new SmtpClient());
                var client = SmtpClients[mailBox];
                if (mailBox.Smtp.TrustAnySSL) client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(mailBox.Smtp.OutboxServerName,
                    mailBox.Smtp.useSsl ? mailBox.Smtp.SslPort : mailBox.Smtp.Port,
                    mailBox.Smtp.useSsl);
                client.Authenticate(mailBox.email_address, mailBox.password);
            }
        }

        public static void SendMessage(MailBox mailBox, MimeMessage mes)
        {
            SmtpClients[mailBox].Send(mes);
        }

        public static void Get(MailBox mailBox)
        {
            var inbox = ImapClients[mailBox].Inbox;
            inbox.Open(FolderAccess.ReadOnly);
            for (int i = 0; i < inbox.Count; i++)
            {
                var message = inbox.GetMessage(i);
                Trace.WriteLine("Subject: {0}", message.Subject);
            }

        }
    }
}
