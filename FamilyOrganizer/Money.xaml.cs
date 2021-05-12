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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FamilyOrganizer
{
    /// <summary>
    /// Логика взаимодействия для Money.xaml
    /// </summary>
    public partial class Money : UserControl
    {
        private readonly FamilyOrganizerContext _context;
        private readonly AppUser _currentUser;

        public void SelectTransactions()
        {
            var month = (int)(MonthComboBox.SelectedItem ?? 0);
            var year = (int)(YearComboBox.SelectedItem ?? 0);

            var itemsSource = _context.Transactions
                .Where(t => t.Date.Year == year && t.Date.Month == month);

            if (_currentUser.Role == "Parent")
            {
                dgSimple.ItemsSource = itemsSource.Select(t => new { t.Date, t.Sum, t.Type, t.ToUser.UserName })
                    .ToList();
            }
            else
            {
                itemsSource = itemsSource.Where(t => t.ToUserId == _currentUser.Id);

                dgSimple.ItemsSource = itemsSource.Select(t => new { t.Date, t.Sum, t.Type }).ToList();
            }
        }

        public Money(FamilyOrganizerContext familyOrganizerContext, AppUser currentUser)
        {
            InitializeComponent();


            _context = familyOrganizerContext;
            _currentUser = currentUser;

            YearComboBox.ItemsSource = _context.Transactions.Select(b => b.Date.Year).Distinct()
                .ToList();

            MonthComboBox.ItemsSource = _context.Transactions.Select(b => b.Date.Month).Distinct()
                .ToList();

            YearComboBox.SelectedIndex = 0;
            MonthComboBox.SelectedIndex = 0;

            SelectTransactions();
        }

        private void AddTransaction_MouseEnter(object sender, MouseEventArgs e)
        {
            AddTransaction.Width += 10;
            AddTransaction.Height += 10;
            AddTransaction.Margin = new Thickness(0, -5, -5, 0);
        }

        private void AddTransaction_MouseLeave(object sender, MouseEventArgs e)
        {
            AddTransaction.Width -= 10;
            AddTransaction.Height -= 10;
            AddTransaction.Margin = new Thickness(0, 0, 0, 0);
        }

        private void AddTransaction_Click(object sender, RoutedEventArgs e)
        {
            AddTransaction at = new AddTransaction(_context, _currentUser);
            at.Show();
        }

        private void dgSimple_Loaded(object sender, RoutedEventArgs e)
        {
            if (_currentUser.Role == "Parent")
            {
                dgSimple.Columns[1].MaxWidth = 60;
            }
        }

        private void UpdateTransaction_Click(object sender, RoutedEventArgs e)
        {
            YearComboBox.ItemsSource = _context.Transactions.Select(b => b.Date.Year).Distinct()
                .ToList();

            MonthComboBox.ItemsSource = _context.Transactions.Select(b => b.Date.Month).Distinct()
                .ToList();

            SelectTransactions();
        }

        private void UpdateTransaction_MouseEnter(object sender, MouseEventArgs e)
        {
            // Margin = "0 1 50 0"
            UpdateTransaction.Width += 10;
            UpdateTransaction.Height += 10;
            UpdateTransaction.Margin = new Thickness(0, -4, 45, 0);
        }

        private void UpdateTransaction_MouseLeave(object sender, MouseEventArgs e)
        {
            UpdateTransaction.Width -= 10;
            UpdateTransaction.Height -= 10;
            UpdateTransaction.Margin = new Thickness(0, 1, 50, 0);
        }

        private void MonthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectTransactions();
        }
    }

}

