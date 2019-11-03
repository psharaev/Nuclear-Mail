using Nuclear_Mail.Models;
using Nuclear_Mail.Models.Data;
using Nuclear_Mail.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Nuclear_Mail
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            Data.Instance.Initialize();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
