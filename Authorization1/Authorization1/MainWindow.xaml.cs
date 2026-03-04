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
using Authorization1.Classes;
using Authorization1.Windows;

namespace Authorization1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void windowActive(Window nextWindow)
        {
            nextWindow.Show();
            this.Close();
        }

        private void btn_authorization_auth_Click(object sender, RoutedEventArgs e)
        {
            var users = Db.Context.Пользователь.ToList();

            string login = txb_authorization_login.Text.Trim();
            string password = txb_authorization_password.Text.Trim();

            bool foundUsers = false;

            foreach (var user in users)
            {
                if (user.Логин == login && user.Пароль == password)
                {
                    foundUsers = true;

                    CurrentUser.currentUser = user;

                    switch (user.Роль)
                    {
                        case "Администратор":
                            windowActive(new AdminList());
                            break;
                        case "Менеджер":
                            windowActive(new ManagerList());
                            break;
                        case "Авторизованный пользоваеть":
                            windowActive(new UserList());
                            break;
                        default:
                            MessageBox.Show("Неизвестная роль пользователя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                    }
                    break;
                }
            }
            if (!foundUsers)
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txb_authorization_login_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_authorization_login.Text = string.Empty;
        }

        private void txb_authorization_login_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txb_authorization_login.Text == "")
            {
                txb_authorization_login.Text = "Логин";
            }
        }

        private void txb_authorization_password_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_authorization_password.Text = string.Empty;
        }

        private void txb_authorization_password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txb_authorization_password.Text == "")
            {
                txb_authorization_password.Text = "Пароль";
            }
        }

        private void btn_authorization_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_authorization_guest_auth_Click(object sender, RoutedEventArgs e)
        {
            windowActive(new GuestList());
        }
    }
}
