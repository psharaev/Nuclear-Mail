using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nuclear_Mail.Models.Patterns;
using Nuclear_Mail.ViewModels.Signals;

namespace Nuclear_Mail.Models.Data
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
            FileInfo[] MailBoxFolders = Directory.CreateDirectory(@"Data\MailBoxes").GetFiles();
            foreach (FileInfo item in MailBoxFolders)
            {
                Saver.LoadPath(out MailBox mailBox, item.FullName);
                mailBoxes.Add(mailBox);
            }
        }

        public void CreateMailBox(in MailBox mailBox)
        {
            string path = $@"Data\MailBoxes\{mailBox.email_address}.dat";
            if (File.Exists(path))
                throw new Exception("Tакой почтовый ящик уже существует");
            Saver.SavePath(mailBox, path);
            ProcessingSignals.Instance.Send(new SignalAddMailBox(mailBox));
        }

        public void RemoveMailBox(in MailBox mailBox)
        {
            Saver.RemovePath($@"Data\MailBoxes\{mailBox.email_address}.dat");
        }

        public void Initialize() { }
    }
}
