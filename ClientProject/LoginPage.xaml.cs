using ClientProject.DatabaseService;
using ClientProject.Model;
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

namespace ClientProject
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            var username = Username.Text;
            var password = Password.Password;

            using (DataContext context = new DataContext())
            {
                bool isLogin = context.Users.Any(user => user.Username == username && user.Password == password);

                if (isLogin)
                {
                    Login();
                    Close();
                }
                else
                {
                    MessageBox.Show("Incorrect credentials");
                }
            }
        }

        public void Login()
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
