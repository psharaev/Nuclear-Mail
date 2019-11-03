using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Nuclear_Mail.Models.Protocols;

namespace Nuclear_Mail.Models
{
    [Serializable]
    public class MailBox:IComparable<MailBox>
    {
        public string email_address = "";
        public string password = "";

        public string Name = "";

        public bool usePop3 = false;
        public bool useImap = false;
        public bool useSmtp = false;

        public POP Pop3 = null;
        public IMAP Imap = null;
        public SMTP Smtp = null;

        public MailBox(string email_address, string password)
        {
            this.email_address = email_address;
            this.password = password;
            useImap = true;
            useSmtp = true;
            Pop3 = new POP(email_address: email_address);
            Smtp = new SMTP(email_address: email_address);
        }

        public MailBox()
        {

        }

        public int CompareTo(MailBox other)
        {
            if (other == null) return 1;
            return email_address.CompareTo(other.email_address);
        }
        public static bool operator >(MailBox operand1, MailBox operand2)
        {
            return operand1.CompareTo(operand2) == 1;
        }
        public static bool operator <(MailBox operand1, MailBox operand2)
        {
            return operand1.CompareTo(operand2) == -1;
        }
        public static bool operator >=(MailBox operand1, MailBox operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }
        public static bool operator <=(MailBox operand1, MailBox operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }
    }
}
