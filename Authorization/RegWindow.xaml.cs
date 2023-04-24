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

namespace Authorization
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        Model1Container db = new Model1Container();
        public RegWindow()
        {
            InitializeComponent();
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Password == "" || lastName.Text == "" || middleName.Text == "")
            {
                MessageBox.Show("Ошибка пустые поля");
                return;
            }
            if (db.Users.Select(item => item.Login).Contains(login.Text))
            {
                MessageBox.Show("Такой логин существует в системе");
                return;
            }
            User newUser = new User()
            {
                Login = login.Text,
                Password = password.Password,
                LastName = lastName.Text,// добавить проверку на имя
                MiddleName = middleName.Text
            };
            db.Users.Add(newUser);
            db.SaveChanges();
            MessageBox.Show("Вы успешно зарегистрировались");
            MainWindow aw = new MainWindow();
            aw.Show();
            this.Close();

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            RegWindow rw = new RegWindow();
            rw.Show();
            this.Close();
        }
    }
}
