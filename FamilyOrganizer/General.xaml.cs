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
    /// Логика взаимодействия для General.xaml
    /// </summary>
    public partial class General : UserControl
    {
        private readonly FamilyOrganizerContext _context;
        private readonly AppUser _currentUser;

        public General(FamilyOrganizerContext familyOrganizerContext, AppUser currentUser)
        {
            InitializeComponent();

            _context = familyOrganizerContext;
            _currentUser = currentUser;
            commentsList.ItemsSource = _context.Comments.Local.ToBindingList();

            WelcomeLabel.Content = _currentUser.UserName;
            ProfileImage.DataContext = _currentUser;
            Role.Content = _currentUser.Role;
            Balance.Content = currentUser.Balance;

            Comments.ScrollToEnd();
        }
        
        public General()
        {
            InitializeComponent();
        }

        private void sendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MessageInput.Text))
            {
                return;
            }

            var comment = new Comment
            {
                Content = MessageInput.Text,
                User = _currentUser
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();

            MessageInput.Text = "";
            Comments.ScrollToEnd();
        }

        private void sendMessage_MouseEnter(object sender, MouseEventArgs e)
        {
            sendMessage.Width += 10;
            sendMessage.Height += 10;
            sendMessage.Margin = new Thickness(0, 0, 5, 25);
        }

        private void sendMessage_MouseLeave(object sender, MouseEventArgs e)
        {
            sendMessage.Width -= 10;
            sendMessage.Height -= 10;
            sendMessage.Margin = new Thickness(0, 0, 10, 30);
        }

        private void MessageInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //e.Handled = MessageInput.Text.Length >= 25;
        }

        private void MessageInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 25)
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, 25);
            }
            (sender as TextBox).CaretIndex = 25;
        }
    }
}
