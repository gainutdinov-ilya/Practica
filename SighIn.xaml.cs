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
    /// Логика взаимодействия для SighIn.xaml
    /// </summary>
    public partial class SighIn : Window
    {
        public SighIn()
        {
            InitializeComponent();
        }

        private void Auth(object sender, RoutedEventArgs e)
        {
            Button.IsEnabled = false;
            //проверка на правильность формы
            if (Login.Text.Length < 6 || Login.Text.Length > 16 || Login.Text.Replace(" ", string.Empty).Length < Login.Text.Length)
            {
                MessageBox.Show("Логин может иметь длинну от 6 до 16 символов, пробелы недопустимы");
                Button.IsEnabled = true;
                return;
            }
            if (Password.Password.Length < 6 || Password.Password.Length > 32 || Password.Password.Replace(" ", string.Empty).Length < Password.Password.Length)
            {
                MessageBox.Show("Пароль может иметь длинну от 6 до 16 символов, пробелы недопустимы");
                Button.IsEnabled = true;
                return;
            }
            //Выполняем запрос
            using (practiceContext db = new practiceContext())
            {
                User user;
                try
                {
                    user = db.Users.Where(data => data.Password == Encryption.GetSHA256(Password.Password) && data.Login == Login.Text).FirstOrDefault();
                    if(user == null)
                    {
                        throw new InvalidOperationException();
                    }
                }
                catch(InvalidOperationException)
                {
                    MessageBox.Show("Неверный логин или пароль");
                    Button.IsEnabled = true;
                    return;
                }
                //записываем данные которое получили в файл
                Files.WriteUser(user);
                MessageBox.Show("Пользователь авторизован");
                Close();
                Button.IsEnabled = true;
            }
        }
    }
}
