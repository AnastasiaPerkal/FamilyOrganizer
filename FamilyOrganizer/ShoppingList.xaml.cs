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
    /// Логика взаимодействия для Tasks.xaml
    /// </summary>
    public partial class ShoppingList : UserControl
    {
        private readonly FamilyOrganizerContext _context;
        private readonly AppUser _currentUser;

        public void Refresh()
        {
            bool isChecked = false;

            _context.ShoppingPlans.Load();

            while (!isChecked)
            {
                isChecked = true;
                foreach (var sp in _context.ShoppingPlans.Local)
                {
                    if (!_context.ShoppingPlans.Any(p => p.Id == sp.Id))
                    {
                        _context.ShoppingPlans.Local.ToBindingList().Remove(sp);
                        
                        isChecked = false;
                        break;
                    }
                }
            }
            
           

            ShoppingListUnapproved.ItemsSource = null;
            ShoppingListUnapproved.ItemsSource = _context.ShoppingPlans.Local.ToBindingList().Where(p => !p.Accepted);

            ShoppingListApproved.ItemsSource = null;
            ShoppingListApproved.ItemsSource = _context.ShoppingPlans.Local.ToBindingList().Where(p => p.Accepted);
        }

        public ShoppingList()
        {
            InitializeComponent();
        }

        public ShoppingList(FamilyOrganizerContext context, AppUser currentUser)
        {
            InitializeComponent();

            _context = context;
            _currentUser = currentUser;

            ShoppingListUnapproved.ItemsSource = _context.ShoppingPlans.Local.ToBindingList().Where(p => !p.Accepted);
            ShoppingListApproved.ItemsSource = _context.ShoppingPlans.Local.ToBindingList().Where(p => p.Accepted);
        }

        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ItemsToBuyInput.Text) || ItemsToBuyInput.Text == "What to buy?")
            {
              //  Refresh();
                return;
            }
            var shoppingPlan = new ShoppingPlan
            {
                Item = ItemsToBuyInput.Text
            };

            if (_currentUser.Role == "Parent")
            {
                shoppingPlan.Accepted = true;
            }
            else
            {
                shoppingPlan.Accepted = false;
            }

            if (! _context.ShoppingPlans.Any(p => p.Item == shoppingPlan.Item))
            {
                _context.ShoppingPlans.Add(shoppingPlan);
           
                try
                {
                    _context.SaveChanges();
                }
                catch
                {
                    Refresh();
                }
            }
           
            ItemsToBuyInput.Text = "What to buy?";
            ItemsToBuyInput.Foreground = Brushes.Gray;
            addItem.Focus();
            Refresh();
        }

        private void addItem_MouseEnter(object sender, MouseEventArgs e)
        {
            addItem.Width += 10;
            addItem.Height += 10;
            addItem.Margin = new Thickness(130, -5, 0, 0);
        }

        private void addItem_MouseLeave(object sender, MouseEventArgs e)
        {
            addItem.Width -= 10;
            addItem.Height -= 10;
            addItem.Margin = new Thickness(135, 0, 0, 0);
        }

        private async void approveItem_Click(object sender, RoutedEventArgs e)
        {
            var shoppingplan = (sender as Button).DataContext as ShoppingPlan;
            shoppingplan.Accepted = true;
            _context.Entry(shoppingplan).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            Refresh();
        }

        private void approveItem_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Button).Width += 10;
            (sender as Button).Height += 10;
            (sender as Button).Margin = new Thickness(-8, -5, 0, 0);
        }

        private void approveItem_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Button).Width -= 10;
            (sender as Button).Height -= 10;
            (sender as Button).Margin = new Thickness(-3, 0, 0, 0);
        }

        private void deleteItem_Click(object sender, RoutedEventArgs e)
        {
            var shoppingplan = (sender as Button).DataContext as ShoppingPlan;

            if (_context.ShoppingPlans.Any(p => p.Id == shoppingplan.Id))
            {
                _context.ShoppingPlans.Remove(shoppingplan);
                try
                {
                    _context.SaveChanges();
                }
                catch
                {
                    return;
                }
                Refresh();
            }
            else if (shoppingplan != null)
            {
                _context.ShoppingPlans.Local.ToBindingList().Remove(shoppingplan);
                Refresh();
            }
            
        }

        private void deleteItem_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Button).Width += 10;
            (sender as Button).Height += 10;
            (sender as Button).Margin = new Thickness(-13, -5, 0, 0);
        }

        private void deleteItem_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Button).Width -= 10;
            (sender as Button).Height -= 10;
            (sender as Button).Margin = new Thickness(-8, 0, 0, 0);
        }

        private void approveItem_Loaded(object sender, RoutedEventArgs e)
        {
            if (_currentUser.Role != "Parent")
            {
                (sender as Button).Visibility = Visibility.Hidden;
            }
        }

        private void deleteItem1_Loaded(object sender, RoutedEventArgs e)
        {
            if (_currentUser.Role != "Parent")
            {
                (sender as Button).Visibility = Visibility.Collapsed;
            }
        }

        private void Separator_Loaded(object sender, RoutedEventArgs e)
        {
            if (_currentUser.Role != "Child")
            {
                (sender as Label).Visibility = Visibility.Collapsed;
            }
        }

        private void deleteItem1_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Button).Width += 10;
            (sender as Button).Height += 10;
            (sender as Button).Margin = new Thickness(-5, -5, 0, 0);
        }

        private void deleteItem1_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Button).Width -= 10;
            (sender as Button).Height -= 10;
            (sender as Button).Margin = new Thickness(0, 0, 0, 0);
        }

        private void ItemsToBuyInput_GotFocus(object sender, RoutedEventArgs e)
        {
            ItemsToBuyInput.Text = "";
            ItemsToBuyInput.Foreground = Brushes.Black;
        }

        private void ItemsToBuyInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ItemsToBuyInput.Text == "")
            {
                ItemsToBuyInput.Text = "What to buy?";
                ItemsToBuyInput.Foreground = Brushes.Gray;
            }
        }

        private void ItemsToBuyInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 14)
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, 14);
            }
            (sender as TextBox).CaretIndex = 14;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Refresh();
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            Refresh();
        }
    }
}
