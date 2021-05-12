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
    /// Логика взаимодействия для Family.xaml
    /// </summary>
    public partial class Family : UserControl
    {
        public readonly FamilyOrganizerContext _context;
        private readonly AppUser _currentUser;

        public Family()
        {
            InitializeComponent();
        }

        public Family(FamilyOrganizerContext familyOrganizerContext, AppUser currentUser)
        {
            InitializeComponent();
            _context = familyOrganizerContext;
            _currentUser = currentUser;
            usersList.ItemsSource = _context.AppUsers.Local.ToBindingList().Where(u => u.Id != _currentUser.Id);
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            Register r = new Register(_context);
            r.Show();
        }

        private void AddUser_MouseEnter(object sender, MouseEventArgs e)
        {
            //  Margin="70 0 0 0"
            AddUser.Width += 10;
            AddUser.Height += 10;
            AddUser.Margin = new Thickness(65, -5, 0, 0);
        }

        private void AddUser_MouseLeave(object sender, MouseEventArgs e)
        {
            AddUser.Width -= 10;
            AddUser.Height -= 10;
            AddUser.Margin = new Thickness(70, 0, 0, 0);
        }

        private void UpdateTransaction_MouseEnter(object sender, MouseEventArgs e)
        {
            // Margin = "20 1 0 0
            UpdateTransaction.Width += 10;
            UpdateTransaction.Height += 10;
            UpdateTransaction.Margin = new Thickness(15, -4, 0, 0);
        }

        private void UpdateTransaction_MouseLeave(object sender, MouseEventArgs e)
        {
            UpdateTransaction.Width -= 10;
            UpdateTransaction.Height -= 10;
            UpdateTransaction.Margin = new Thickness(20, 1, 0, 0);
        }

        private void UpdateTransaction_Click(object sender, RoutedEventArgs e)
        {
            usersList.ItemsSource = null;
            usersList.ItemsSource = _context.AppUsers.Local.ToBindingList().Where(u => u.Id != _currentUser.Id);
        }
    }
}
