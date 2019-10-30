using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nuclear_Mail.Models.Patterns;

namespace Nuclear_Mail.Models
{
    public class Data : Singleton<Data>
    {
        private static object _lockMailBoxes = new object();
        private List<MailBox> mailBoxes = new List<MailBox>();
        public List<MailBox> MailBoxes
        {
            get => mailBoxes;
            set
            {
                lock (_lockMailBoxes)
                {
                    mailBoxes = value;
                }
            }
        }

        public Data()
        {

        }

        public void Initialize() { }
    }
}
