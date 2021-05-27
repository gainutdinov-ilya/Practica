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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // проверка авторизации 
            LoginChecker();
        }

        private void CreateRegWindow(object sender, RoutedEventArgs e)
        {
            Register window = new Register();
            window.Owner = this;
            window.ShowDialog();
        }

        private void CreateAuthWindow(object sender, RoutedEventArgs e)
        {
            SighIn window = new SighIn();
            window.Owner = this;
            window.ShowDialog();
        }

        private void LoginChecker()
        {
            if (Files.ReadUser() != null)
            {
                Profile profile = new Profile();
                profile.Show();
                Close();
                return;
            }
            return;
        } 
    }
}
