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
            if (Name.Text.Length < 2 || Name.Text.Length > 32) MessageBox.Show("Имя может иметь длинну от 3 до 32 символов");
            else if (Surname.Text.Length < 2 || Name.Text.Length > 32) MessageBox.Show("Фамилия может иметь длинну от 3 до 32 символов");
            
        }
    }
}
