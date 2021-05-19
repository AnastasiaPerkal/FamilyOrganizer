using FamilyOrganizer.DB;
using FamilyOrganizer.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace FamilyOrganizer
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : UserControl
    {
        private readonly FamilyOrganizerContext _context;
        private readonly AppUser _currentUser;
        private int PhotoId;

        public Edit()
        {
            InitializeComponent();
        }

        public Edit(FamilyOrganizerContext familyOrganizerContext, AppUser currentUser)
        {
            InitializeComponent();
            _context = familyOrganizerContext;
            _currentUser = currentUser;

            BitmapImage icon = new BitmapImage();
            icon.BeginInit();
            icon.UriSource = new Uri(_currentUser.Photo.Source, UriKind.Relative);
            icon.EndInit();
            ProfileAvatar.Source = icon;

            PhotoId = _currentUser.PhotoId;

            TextBoxCurrentUsername.Text = _currentUser.UserName;
        }

        

        private void right_Click(object sender, RoutedEventArgs e)
        {

            if (PhotoId == 12)
            {
                PhotoId = 1;
            }
            else
            {
                PhotoId++;
            }
            SetPhoto();
        }

        public void SetPhoto()
        {
            var photo = _context.Photos.FirstOrDefault(p => p.Id == PhotoId);
            BitmapImage icon = new BitmapImage();
            icon.BeginInit();
            icon.UriSource = new Uri(photo.Source, UriKind.Relative);
            icon.EndInit();
            ProfileAvatar.Source = icon;
        }

        private void left_Click(object sender, RoutedEventArgs e)
        {
            if (PhotoId == 1)
            {
                PhotoId = 12;
            }
            else
            {
                PhotoId--;
            }
            SetPhoto();
        }

        private async void saveLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = TextBoxCurrentUsername.Text;
            var password = TextBoxPassword.Password;
            if (string.IsNullOrWhiteSpace(username))
            {
                var mb = new FamilyOrganizerMessageBox("Username cannot be empty");
                mb.Show();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                var mb = new FamilyOrganizerMessageBox("Invalid password");
                mb.Show();
                return;
            }

            if (_context.AppUsers.Any(u => u.UserName == username && u.UserName != _currentUser.UserName))
            {
                var mb = new FamilyOrganizerMessageBox("Username is taken");
                mb.Show();
                return;
            }

            var hashedPassword = PasswordHash.CreateHash(password);

            if (password != "k*7m\\Z!~")
            {
                _currentUser.Password = hashedPassword;  
            }

            _currentUser.UserName = username;
            _currentUser.Photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == PhotoId);
            _context.Entry(_currentUser).State = EntityState.Modified;
            if (await _context.SaveChangesAsync() > 0)
            {
                var mb = new FamilyOrganizerMessageBox("Your changes have been applied");
                mb.Show();
            }
        }

        private void TextBoxPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void TextBoxPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxPassword.Password = "";
        }

        private void TextBoxPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxPassword.Password == "")
                TextBoxPassword.Password = "k*7m\\Z!~";
        }

        private void right_MouseEnter(object sender, MouseEventArgs e)
        {
            right.Width += 10;
            right.Height += 10;
            right.Margin = new Thickness(0, 0, -10, 0);
        }

        private void right_MouseLeave(object sender, MouseEventArgs e)
        {
            right.Width -= 10;
            right.Height -= 10;
            right.Margin = new Thickness(0);
        }

        private void left_MouseEnter(object sender, MouseEventArgs e)
        {
            left.Width += 10;
            left.Height += 10;
            left.Margin = new Thickness(-10, 0, 0, 0);
        }

        private void left_MouseLeave(object sender, MouseEventArgs e)
        {
            left.Width -= 10;
            left.Height -= 10;
            left.Margin = new Thickness(0);
        }

        private void saveLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            saveLogin.Width += 10;
            saveLogin.Height += 10;
            saveLogin.Margin = new Thickness(0, 50, 5, 5);

        }

        private void saveLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            saveLogin.Width -= 10;
            saveLogin.Height -= 10;
            saveLogin.Margin = new Thickness(0, 50, 10, 10);
        }

        private void TextBoxCurrentUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 30)
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, 30);
            }
            (sender as TextBox).CaretIndex = 30;
        }

        private void TextBoxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if ((sender as PasswordBox).Password.Length > 30)
            {
                (sender as PasswordBox).Password = (sender as PasswordBox).Password.Substring(0, 30);
            }
        }
    }
}
