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

namespace Nuclear_Mail
{
    /// <summary>
    /// Логика взаимодействия для WriteLetter.xaml
    /// </summary>
    public partial class WriteLetter : Window
    {
        public WriteLetter()
        {
            InitializeComponent();
        }

        private void Send(object sender, RoutedEventArgs e)
        {
        }
        
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddAttachments(object sender, RoutedEventArgs e)
        {
        }
    }
}
