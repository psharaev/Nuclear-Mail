using System;
using System.Collections.Generic;
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
using Nuclear_Mail.ViewModels;

namespace Nuclear_Mail.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateMailBox.xaml
    /// </summary>
    public partial class CreateMailBox : Window
    {
        private bool ManualMode = false;

        public CreateMailBox()
        {
            InitializeComponent();
        }

        private void AddMailBox(object sender, RoutedEventArgs e)
        {
            Action create;
            if (ManualMode)
            {
                create = () => MailManager.CreateMailBox(Login.Text, Password.Text);
            }
            else
                create = () => MailManager.CreateMailBox(Login.Text, Password.Text);
            try
            {
                create();
            }
            catch
            {

            }
        }
    }
}
