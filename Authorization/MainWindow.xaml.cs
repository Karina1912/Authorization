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

namespace Authorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model1Container db;
        public MainWindow()
        { 
            InitializeComponent();
            db = new Model1Container();
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Password == "")
            {
                MessageBox.Show("Ошибка пустые поля");
            }
            if (db.Users.Select(item => item.Login + " " + item.Password).Contains(login.Text + " " + password.Password))
            {
                MessageBox.Show("Вы авторизированы");
            }
            else
            {
                MessageBox.Show("Ошибка логина/пароля");
            }

        }

        private void Regist_Click(object sender, RoutedEventArgs e)
        {
            RegWindow rw = new RegWindow();
            rw.Show();
            this.Close();
        }
    }
}
