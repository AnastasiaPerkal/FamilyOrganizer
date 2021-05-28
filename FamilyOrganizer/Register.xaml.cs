using FamilyOrganizer.User;
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

namespace FamilyOrganizer
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private readonly FamilyOrganizerContext _context;
        private readonly bool _toMainWindow;

        public bool Checked { get; set; } = false;

        public Register()
        {
            InitializeComponent();
        }


        public Register(FamilyOrganizerContext context, bool ToMainWindow = false)
        {
            InitializeComponent();
            _context = context;
            _toMainWindow = ToMainWindow;
            if (_context.AppUsers.Count() == 0)
            {
                ParentWithCheckBox.Visibility = Visibility.Hidden;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameRegister.Text;

            if (string.IsNullOrEmpty(username))
            {
                var mb = new FamilyOrganizerMessageBox("Username is required");
                mb.Show();
                return;
            }

            if (string.IsNullOrEmpty(PasswordRegister.Password))
            {
                var mb = new FamilyOrganizerMessageBox("Password is required");
                mb.Show();
                return;
            }

            if (PasswordRegister.Password.Length < 6)
            {
                var mb = new FamilyOrganizerMessageBox("Minimum password length is 6");
                mb.Show();
                return;
            }

            if (_context.AppUsers.Any(u => u.UserName == username))
            {
                var mb = new FamilyOrganizerMessageBox("The username is taken");
                mb.Show();
                return;
            }

            if (_context.AppUsers.Count() == 0)
            {
                Checked = true;
            }

            var hashedPassword = PasswordHash.CreateHash(PasswordRegister.Password);

            var user = new AppUser
            {
                UserName = username,
                Password = hashedPassword,
                Role = Checked ? "Parent" : "Child"
            };
            _context.AppUsers.Add(user);

            await _context.SaveChangesAsync();

            if (_toMainWindow)
            {
                var mv = new MainWindow(_context, user);
                mv.Show();
            }
            else
            {
                var mb = new FamilyOrganizerMessageBox("Refresh the page to see the changes");
                mb.Show();
            }

            Close();
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

        private void IsParent_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage checkBox = new BitmapImage();
            checkBox.BeginInit();
            if (Checked)
            {
                checkBox.UriSource = new Uri(@".\Resources\unchecked.png", UriKind.Relative);
                Checked = false;
            }
            else
            {
                checkBox.UriSource = new Uri(@".\Resources\checked.png", UriKind.Relative);
                Checked = true;
            }
            checkBox.EndInit();

            (sender as Button).Background = new ImageBrush { ImageSource = checkBox };
        }

        private void IsParent_MouseEnter(object sender, MouseEventArgs e)
        {
            IsParent.Width += 10;
            IsParent.Height += 10;
            IsParent.Margin = new Thickness(-5, 0, 0, 0);
        }

        private void IsParent_MouseLeave(object sender, MouseEventArgs e)
        {
            IsParent.Width -= 10;
            IsParent.Height -= 10;
            IsParent.Margin = new Thickness(0);
        }

        private void LB_MouseEnter(object sender, MouseEventArgs e)
        {
            LB.Width += 10;
            LB.Height += 10;
            LB.Margin = new Thickness(20, -2, 0, 0);
        }

        private void LB_MouseLeave(object sender, MouseEventArgs e)
        {
            LB.Width -= 10;
            LB.Height -= 10;
            LB.Margin = new Thickness(25, 3, 0, 0);
            ParentLabel.Margin = new Thickness(0);
        }

        private void UsernameRegister_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 10)
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, 10);
            }
            (sender as TextBox).CaretIndex = 10;
        }

        private void PasswordRegister_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if ((sender as PasswordBox).Password.Length > 30)
            {
                (sender as PasswordBox).Password = (sender as PasswordBox).Password.Substring(0, 30);
            }
        }
    }
}
