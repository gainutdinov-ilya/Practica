using System.Windows;

namespace Practica
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    /// 
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            Files.WriteUser(null);
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
