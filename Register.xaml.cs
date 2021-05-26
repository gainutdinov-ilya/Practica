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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        public void CheckForm(object sender, RoutedEventArgs e)
        {
            //Проверка правильности заполнения формы
            if (Name.Text.Length < 2 || Name.Text.Length > 32 || Name.Text.Replace(" ", string.Empty).Length < Name.Text.Length)
            {
                MessageBox.Show("Имя может иметь длинну от 2 до 32 символов, пробелы недопустимы");
                return;
            }
            if (Surname.Text.Length < 2 || Surname.Text.Length > 32 || Surname.Text.Replace(" ",string.Empty).Length < Surname.Text.Length) 
            {    
                MessageBox.Show("Фамилия может иметь длинну от 2 до 32 символов, пробелы недопустимы");
                return;
            }
            if (Login.Text.Length < 6 || Login.Text.Length > 16 || Login.Text.Replace(" ", string.Empty).Length < Login.Text.Length)
            {
                MessageBox.Show("Логин может иметь длинну от 6 до 16 символов, пробелы недопустимы");
                return;
            }
            if (Password.Password.Length < 6 || Password.Password.Length > 32 || Password.Password.Replace(" ", string.Empty).Length < Password.Password.Length)
            {
                MessageBox.Show("Пароль может иметь длинну от 6 до 16 символов, пробелы недопустимы");
                return;
            }
            if (Password.Password != RepeatedPassword.Password)
            {
                MessageBox.Show("Введёные пароли не совпадают");
                return;
            }
            if (DateOfBirth.SelectedDate == null)
            {
                MessageBox.Show("Выберите Дату");
                return;
            }
            //
        }
    }
}
