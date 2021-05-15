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
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для UserCard.xaml
    /// </summary>
    public partial class UserCard : UserControl
    {
        private FamilyOrganizerContext _context;

        public UserCard()
        {
            InitializeComponent();
        }

        private void AddMoney_MouseEnter(object sender, MouseEventArgs e)
        {
            AddMoney.Width += 10;
            AddMoney.Height += 10;
            DeleteUser.Margin = new Thickness(-5, 0, 0, 0);
            AddMoney.Margin = new Thickness(-5, 0, 0, 0);
        }

        private void AddMoney_MouseLeave(object sender, MouseEventArgs e)
        {
            AddMoney.Width -= 10;
            AddMoney.Height -= 10;
            DeleteUser.Margin = new Thickness(0);
            AddMoney.Margin = new Thickness(0, 5, 0, 0);
        }

        private void DeleteUser_MouseEnter(object sender, MouseEventArgs e)
        {
            DeleteUser.Width += 10;
            DeleteUser.Height += 10;
            DeleteUser.Margin = new Thickness(-5, -5, 0, 0);
            AddMoney.Margin = new Thickness(-5, 0, 0, 0);
        }

        private void DeleteUser_MouseLeave(object sender, MouseEventArgs e)
        {
            DeleteUser.Width -= 10;
            DeleteUser.Height -= 10;
            DeleteUser.Margin = new Thickness(0);
            AddMoney.Margin = new Thickness(0, 5, 0, 0);
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = DataContext as AppUser;

            if (_context == null)
            {
                var a = VisualTreeHelper.GetParent(this);
                while(!(a is Family))
                {
                    a = VisualTreeHelper.GetParent(a);
                }

                _context = (a as Family)._context;
            }

            if (!_context.AppUsers.Any(u => u.Id == currentUser.Id))
                return;

            _context.AppUsers.Remove(currentUser);

            var currentBalance = _context.AppUsers.Where(u => u.UserName != currentUser.UserName).Sum(u => u.Balance);

            var currentBalanceEntry = _context.Balances.OrderByDescending(b => b.Date).FirstOrDefault();
            
            if (currentBalanceEntry.Date.Day == DateTime.Now.Day)
            {
                _context.Balances.Remove(currentBalanceEntry);
            }

            _context.Balances.Add(new Balance
            {
                Date = DateTime.Now,
                CurrentBalance = currentBalance
            });

            _context.SaveChanges();
        }

        private void AddMoney_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = DataContext as AppUser;
            if (_context == null)
            {
                var a = VisualTreeHelper.GetParent(this);
                while (!(a is Family))
                {
                    a = VisualTreeHelper.GetParent(a);
                }

                _context = (a as Family)._context;
            }

            if (!_context.AppUsers.Any(u => u.Id == currentUser.Id))
                return;

            AddMoneyAdmin ama = new AddMoneyAdmin(_context, currentUser);
            ama.Show();
        }
    }
}
