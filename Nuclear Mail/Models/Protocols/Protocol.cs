namespace Nuclear_Mail.Models.Protocols
{
    public abstract class Protocol
    {
        public PostalProtocol protocol;
        public bool useSsl = false;
        public int Port = 0;
        public int SslPort = 0;
    }

    public enum PostalProtocol
    {
        POP3 = 0,
        IMAP = 1,
        SMTP = 2
    }

    public abstract class InboxProtocol : Protocol
    {
        public string InboxServerName = "";
    }
    public abstract class OutboxProtocol : Protocol
    {
        public string OutboxServerName = "";
    }

    public class POP3 : InboxProtocol 
    {
        public new PostalProtocol protocol = PostalProtocol.POP3;
    }
    public class IMAP : InboxProtocol 
    {
        public new PostalProtocol protocol = PostalProtocol.IMAP;
    }
    public class SMTP : OutboxProtocol
    {
        public new PostalProtocol protocol = PostalProtocol.SMTP;
    }
}
