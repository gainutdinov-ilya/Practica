using System;
using System.Linq;
using System.Windows;

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

        private void CheckForm(object sender, RoutedEventArgs e)
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
            //проверка и регистрация пользователя
            using (practiceContext db = new practiceContext())
            {   //проверяем логин
                var users = (from User in db.Users where User.Login == $"{Login.Text}" select User).ToList();
                foreach(User user in users)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                    return;
                }
                //Получаем последний ID
                int id;
                try
                {
                    id = (from User in db.Users orderby User.UserId select User.UserId).Single<int>() + 1;
                }
                catch (InvalidOperationException)
                {
                    id = 1;
                }
                //заполняем поля регистрации
                User register = new User { UserId = id, Name = Name.Text, Surname = Surname.Text, Login = Login.Text, DateOfBirth = DateOfBirth.SelectedDate.Value, Password = Encryption.GetSHA256(Password.Password), BanAuth = DateTime.Now, IsAdmin = false, LastLogin = DateTime.Now };
                //Сохраняем изменения
                db.Add(register);
                db.SaveChanges();
                MessageBox.Show("Пользователь успешно зарегестрирован");
            }
            Close();
        }

        private void DeleteUserByLogin(object sender, RoutedEventArgs e)
        {   //проверяем поле на заполнение
            if (Login.Text.Length < 6 || Login.Text.Length > 16 || Login.Text.Replace(" ", string.Empty).Length < Login.Text.Length)
            {
                MessageBox.Show("Логин может иметь длинну от 6 до 16 символов, пробелы недопустимы");
                return;
            }//получаем пользователя с логином 
            using (practiceContext db = new practiceContext())
            {
                User user;
                try
                {
                    user = (from User in db.Users where User.Login == $"{Login.Text}" select User).Single();
                }catch(InvalidOperationException)
                {
                        MessageBox.Show("Пользователь не найден");
                        return;
                }
                //спрашиваем прежде чем удалять
                if(MessageBox.Show($"Удалить пользователя {user.Login}", "Нет", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    //Удаляем и сохраняем изменения
                    db.Remove(user);
                    db.SaveChanges();
                }
            }
        }
    }
}
