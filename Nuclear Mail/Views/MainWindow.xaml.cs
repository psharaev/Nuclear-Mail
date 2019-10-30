using Nuclear_Mail.Views;
using System;
using System.Collections.Generic;
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

namespace Nuclear_Mail
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WriteLetter(object sender,RoutedEventArgs e)
        {
            WriteLetter win = new WriteLetter();

            win.Show();
        }

        private void CreateMailBox(object sender, RoutedEventArgs e)
        {
            CreateMailBox win = new CreateMailBox();

            win.Show();
        }
    }
}
