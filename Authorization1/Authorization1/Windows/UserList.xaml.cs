using Authorization1.Classes;
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

namespace Authorization1.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserList.xaml
    /// </summary>
    public partial class UserList : Window
    {
        public UserList()
        {
            InitializeComponent();

            if (CurrentUser.currentUser != null)
            {
                txb_UserFullName.Text = CurrentUser.currentUser.ФИО;
            }
        }
        private void btn_SwitchUser_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.currentUser = null;

            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
