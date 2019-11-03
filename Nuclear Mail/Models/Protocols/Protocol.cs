using System;

namespace Nuclear_Mail.Models.Protocols
{
    [Serializable]
    public abstract class Protocol
    {
        public PostalProtocol protocol;
        public bool useSsl = false;
        public bool TrustAnySSL = false;
        public int Port = 0;
        public int SslPort = 0;
    }

    public enum PostalProtocol
    {
        POP = 0,
        IMAP = 1,
        SMTP = 2
    }

    [Serializable]
    public abstract class InboxProtocol : Protocol
    {
        public string InboxServerName = "";
    }
    [Serializable]
    public abstract class OutboxProtocol : Protocol
    {
        public string OutboxServerName = "";
    }
    [Serializable]
    public class POP : InboxProtocol 
    {
        public new PostalProtocol protocol = PostalProtocol.POP;
        public POP(bool useSsl = true, int Port = 110, int SslPort = 995,string email_address = null)
        {
            this.useSsl = useSsl;
            this.Port = Port;
            this.SslPort = SslPort;
            if (email_address != null) InboxServerName = "pop." + email_address.Split('@')[1];
        }
    }
    [Serializable]
    public class IMAP : InboxProtocol 
    {
        public new PostalProtocol protocol = PostalProtocol.IMAP;
        public IMAP(bool useSsl = true, int Port = 143, int SslPort = 993, string email_address = null)
        {
            this.useSsl = useSsl;
            this.Port = Port;
            this.SslPort = SslPort;
            if (email_address != null) InboxServerName = "imap." + email_address.Split('@')[1];
        }
    }
    [Serializable]
    public class SMTP : OutboxProtocol
    {
        public new PostalProtocol protocol = PostalProtocol.SMTP;
        public SMTP(bool useSsl = true, int Port = 587, int SslPort = 465, string email_address = null)
        {
            this.useSsl = useSsl;
            this.Port = Port;
            this.SslPort = SslPort;
            if (email_address != null) OutboxServerName = "smtp." + email_address.Split('@')[1];
        }
    }
}
