using Microsoft.Win32;
using MimeKit;
using Nuclear_Mail.Models;
using Nuclear_Mail.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Nuclear_Mail.Views
{
    /// <summary>
    /// Логика взаимодействия для WriteLetter.xaml
    /// </summary>
    public partial class WriteLetter : Window
    {
        private MailBox mailBox;
        private SortedSet<string> attachments = new SortedSet<string>();

        public WriteLetter(MailBox mailBox)
        {
            InitializeComponent();
            this.mailBox = mailBox;
            FromName.Text = mailBox.Name;
            FromAddress.Text = mailBox.email_address;
        }

        private void Send(object sender, RoutedEventArgs e)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(FromName.Text, FromAddress.Text));
            message.To.Add(new MailboxAddress(ToName.Text, ToAddress.Text));
            message.Subject = Subject.Text;

            var Builder = new BodyBuilder();
            Builder.TextBody = Body.Text;

            foreach (string item in attachments)
            {
                Trace.WriteLine(item);
                Builder.Attachments.Add(item);
            }

            message.Body = Builder.ToMessageBody();
            MailManager.SendMessage(mailBox, message);
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddAttachments(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                    attachments.Add(filename);
            }
        }
    }
}
