using FamilyOrganizer.DB;
using FamilyOrganizer.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddTransaction.xaml
    /// </summary>
    public partial class AddTransaction : Window
    {
        private static readonly Regex _numeric = new Regex(@"^[0-9\.]+$");
        private static readonly Regex _intAndFloat = new Regex(@"^\d+(?:\.\d+)?$");
        private readonly FamilyOrganizerContext _context;
        private readonly AppUser _currentUser;

        public AddTransaction(FamilyOrganizerContext context, AppUser currentUser)
        {
            InitializeComponent();
            _context = context;
            _currentUser = currentUser;
            ToUser.ItemsSource = _context.AppUsers.Where(u => u.UserName != _currentUser.UserName)
                .Select(u => u.UserName).ToList();

            if (_context.AppUsers.Count() <= 1)
            {
                TransferItem.IsEnabled = false;
            }
            if (_currentUser.Role == "Child")
            {
                DepositItem.IsEnabled = false;
            }
        }
        public AddTransaction()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TranSum.Text))
            {
                var mb = new FamilyOrganizerMessageBox("The sum is required");
                mb.Show();
                return;
            }

            if (!_intAndFloat.IsMatch(TranSum.Text))
            {
                var mb = new FamilyOrganizerMessageBox("The sum is invalid");
                mb.Show();
                return;
            }

            var toUsername = ToUser.SelectedItem?.ToString();
            var sum = -Convert.ToDouble(TranSum.Text);
            var toUser = _currentUser;
            var type = "Money transfer";

            if (_currentUser.Balance < Math.Abs(sum) && (TypeChoice.SelectedItem as ComboBoxItem).Content?.ToString() != "Deposit")
            {
                var mb = new FamilyOrganizerMessageBox("You don't have enough money");
                mb.Show();
                return;
            }

            switch ((TypeChoice.SelectedItem as ComboBoxItem)?.Content?.ToString())
            {
                case "Transfer":
                    _currentUser.Balance += sum;
                    _context.Entry(_currentUser).State = EntityState.Modified;
                    toUser = _context.AppUsers.FirstOrDefault(u => u.UserName == toUsername);
                    sum = -sum;
                    break;
                case "Deposit":
                    sum = -sum;
                    _currentUser.Balance += sum;
                    _context.Entry(_currentUser).State = EntityState.Modified;
                    type = "Deposit";
                    break;
                case "Expense":
                    _currentUser.Balance += sum;
                    _context.Entry(_currentUser).State = EntityState.Modified;
                    type = (CategoryChoice.SelectedItem as ComboBoxItem).Content?.ToString();
                    break;
                default:
                    return;
            }

            var transaction = new Transaction
            {
                Type = type,
                Date = DateTime.Now,
                Sum = sum,
                ToUser = toUser
            };

            _context.Transactions.Add(transaction);

            if (transaction.ToUser != _currentUser) // transfer
            {
                toUser.Balance += sum;
                _context.Entry(toUser).State = EntityState.Modified;
                _context.Transactions.Add(new Transaction
                {
                    Type = transaction.Type,
                    Date = transaction.Date,
                    Sum = -transaction.Sum,
                    ToUser = _currentUser
                });
            }
            else
            {
                var currentBalanceEntry = _context.Balances.OrderByDescending(b => b.Date).FirstOrDefault();
                if (currentBalanceEntry == null)
                    currentBalanceEntry = new Balance { Date = DateTime.Now };

                var currentBalance = _context.AppUsers.Sum(u => u.Balance);

                if (currentBalanceEntry.Date.Day == transaction.Date.Day && _context.Balances.Count() > 0)
                {
                    _context.Balances.Remove(currentBalanceEntry);
                }

                _context.Balances.Add(new Balance
                {
                    Date = transaction.Date,
                    CurrentBalance = currentBalance + sum
                });
            }

            _context.SaveChanges();
            TranSum.Text = "";

        }

        private void TranSum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !_numeric.IsMatch(e.Text);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            var mb = new FamilyOrganizerMessageBox("Refresh the page to see the changes");
            mb.Show();
            Close();
        }

        private void CloseBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            CloseBtn.Width += 10;
            CloseBtn.Height += 10;
            CloseBtn.Margin = new Thickness(-5, -5, 0, 0);
        }

        private void CloseBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            CloseBtn.Width -= 10;
            CloseBtn.Height -= 10;

            CloseBtn.Margin = new Thickness(0);
        }

        private void AddBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            AddBtn.Width += 10;
            AddBtn.Height += 10;
            AddBtn.Margin = new Thickness(-5, 60, 0, 0);
        }

        private void AddBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            AddBtn.Width -= 10;
            AddBtn.Height -= 10;
            AddBtn.Margin = new Thickness(0, 65, 0, 0);
        }

        private void TranSum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 13)
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, 13);
            }
            (sender as TextBox).CaretIndex = 13;
        }
    }
}
