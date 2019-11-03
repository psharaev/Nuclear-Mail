using Nuclear_Mail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclear_Mail.ViewModels.Signals
{
    public struct SignalAddMailBox
    {
        public MailBox mailBox;
        public SignalAddMailBox(MailBox mailBox)
        {
            this.mailBox = mailBox;
        }
    }
}
