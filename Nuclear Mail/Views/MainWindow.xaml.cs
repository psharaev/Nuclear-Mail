using Nuclear_Mail.Models;
using Nuclear_Mail.ViewModels;
using Nuclear_Mail.ViewModels.Signals;
using Nuclear_Mail.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nuclear_Mail.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , IReceive<SignalAddMailBox>
    {
        private MailBox CurrentMailBox;
        private static readonly UIElement MainMailBoxButton = (UIElement)Application.Current.Resources["MainMailBoxButton"];
        public MainWindow()
        {
            InitializeComponent();
            CurrentMailBox = MailManager.GetMailBoxes()[0];
            MailManager.GetMailBoxes().ForEach(x => AddMailBoxButton(x));
            ProcessingSignals.Instance.Add(this);
        }

        public void AddMailBoxButton(MailBox item)
        {
            if (item == null) return;

            Button button = (Button)MainMailBoxButton.CloneViaXamlSerialization();
            button.Content = char.ToUpper(item.email_address[0]);
            button.ToolTip = item.email_address;
            MainMailBoxesIcon.Children.Add(button);
            
            MailController.CreateClient(item);
        }

        private void WriteLetter(object sender,RoutedEventArgs e)
        {
            WriteLetter win = new WriteLetter(CurrentMailBox);

            win.Show();
        }

        private void CreateMailBox(object sender, RoutedEventArgs e)
        {
            CreateMailBox win = new CreateMailBox();

            win.Show();
        }

        void IReceive<SignalAddMailBox>.HandleSignal(SignalAddMailBox arg)
        {
            AddMailBoxButton(arg.mailBox);
        }
    }
}
