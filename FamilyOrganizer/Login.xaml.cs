using FamilyOrganizer.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace FamilyOrganizer
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        private readonly FamilyOrganizerContext context;
        public Login()
        {
            InitializeComponent();
        }

        public Login(FamilyOrganizerContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameLogin.Text) || string.IsNullOrEmpty(PasswordLogin.Password))
            {
                var mb = new FamilyOrganizerMessageBox("Enter both login and password");
                mb.Show();
                //MessageBox.Show("why r u gay?");
                return;
            }

            // после проверок
            var username = UsernameLogin.Text;

            var user = context.AppUsers.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                var mb = new FamilyOrganizerMessageBox("Check username and password");
                mb.Show();
               // MessageBox.Show("u r gay.");
                return;
            }

            var password = PasswordLogin.Password;

            if (PasswordHash.ValidatePassword(password, user.Password))
            {
                var mw = new MainWindow(context, user);
                mw.Show();
                Close();
            }
            else
            {
                var mb = new FamilyOrganizerMessageBox("Check username and password");
                mb.Show();
               // MessageBox.Show("u r gay.");
                return;
            }
            
        }

        private void Close_MouseEnter(object sender, MouseEventArgs e)
        {
            Close.Width += 10;
            Close.Height += 10;
            Close.Margin = new Thickness(0, -5, -5, 0);
        }

        private void Close_MouseLeave(object sender, MouseEventArgs e)
        {
            Close.Width -= 10;
            Close.Height -= 10;

           Close.Margin = new Thickness(0);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            LB.Width += 10;
            LB.Height += 10;
            LB.Margin = new Thickness(20, -2, 0, 0);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            LB.Width -= 10;
            LB.Height -= 10;

            LB.Margin = new Thickness(25, 3, 0, 0);
        }
    }
}

