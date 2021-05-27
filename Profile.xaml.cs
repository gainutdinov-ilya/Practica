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

namespace Practica
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            if (DataIsActual() == false) Logout();
        }

        private bool DataIsActual()
        {
            using (practiceContext db = new practiceContext())
            {
                User user = Files.ReadUser();
                MessageBox.Show(((User)db.Users.Where(data => data.Login == user.Login && data.Password == user.Password).FirstOrDefault() == user).ToString());
                if (db.Users.Where(data => data.Login == user.Login && data.Password == user.Password).FirstOrDefault() == user) return true;

            }
            return false;
        }

        private void Logout()
        {
            Files.WriteUser(null);
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
