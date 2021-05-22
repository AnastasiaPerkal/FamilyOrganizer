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
    /// Логика взаимодействия для Diary.xaml
    /// </summary>
    public partial class Diary : UserControl
    {
        private readonly FamilyOrganizerContext _context;
        private readonly AppUser _currentUser;

        public Diary()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            TasksList.ItemsSource = null;
            TasksList.ItemsSource = _context.TodayPlans.Local.ToBindingList().Where(p => p.IsAdded == true && _currentUser.Id == p.UserId);

            TaskListRoutine.ItemsSource = null;
            TaskListRoutine.ItemsSource = _context.TodayPlans.Local.ToBindingList().Where(p => p.IsRoutine == true && _currentUser.Id == p.UserId);
        }

        public Diary(FamilyOrganizerContext familyOrganizerContext, AppUser currentUser)
        {
            InitializeComponent();
            _context = familyOrganizerContext;
            _currentUser = currentUser;

            TaskListRoutine.ItemsSource = _context.TodayPlans.Local.ToBindingList().Where(p => p.IsRoutine == true && _currentUser.Id == p.UserId);
            TasksList.ItemsSource = _context.TodayPlans.Local.ToBindingList().Where(p => p.IsAdded == true && _currentUser.Id == p.UserId);
        }

        private void deleteItem_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Button).Width -= 10;
            (sender as Button).Height -= 10;
            (sender as Button).Margin = new Thickness(-8, 0, 0, 0);
        }

        private void deleteItem_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Button).Width += 10;
            (sender as Button).Height += 10;
            (sender as Button).Margin = new Thickness(-13, -5, 0, 0);
        }

        private async void deleteItem_Click(object sender, RoutedEventArgs e)
        {
            var todayPlan = (sender as Button).DataContext as TodayPlan;

            _context.TodayPlans.Remove(todayPlan);
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

        private async void approveItem_Click(object sender, RoutedEventArgs e)
        {
            var todayPlan = (sender as Button).DataContext as TodayPlan;
            todayPlan.IsAdded = true;
            _context.Entry(todayPlan).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            Refresh();
        }

        private void deleteItem1_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Button).Width -= 10;
            (sender as Button).Height -= 10;
            (sender as Button).Margin = new Thickness(0, 0, 0, 0);
        }

        private async void deleteItem1_Click(object sender, RoutedEventArgs e)
        {
            var todayPlan = (sender as Button).DataContext as TodayPlan;

            if (todayPlan.IsRoutine)
            {
                todayPlan.IsAdded = false;
                _context.Entry(todayPlan).State = EntityState.Modified;
            }
            else
            {
                _context.TodayPlans.Remove(todayPlan);
            }
            await _context.SaveChangesAsync();

            Refresh();
        }

        private void addTaskSuggestion_MouseLeave(object sender, MouseEventArgs e)
        {
            addTaskSuggestion.Width -= 10;
            addTaskSuggestion.Height -= 10;
            addTaskSuggestion.Margin = new Thickness(0);
        }

        private void addTaskSuggestion_MouseEnter(object sender, MouseEventArgs e)
        {
            addTaskSuggestion.Width += 10;
            addTaskSuggestion.Height += 10;
            addTaskSuggestion.Margin = new Thickness(-5, -5, 0, 0);
        }

        private async void addTaskSuggestion_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TasksSuggestionsInput.Text) || TasksSuggestionsInput.Text == "Routine tasks")
            {
                return;
            }
            var todayPlan = new TodayPlan
            {
                Task = TasksSuggestionsInput.Text,
                IsRoutine = true,
                IsAdded = false,
                UserId = _currentUser.Id
            };
            _context.TodayPlans.Add(todayPlan);
            await _context.SaveChangesAsync();

            Refresh();

            TasksSuggestionsInput.Text = "Routine tasks";
            TasksSuggestionsInput.Foreground = Brushes.Gray;
        }

        private void addTask_MouseLeave(object sender, MouseEventArgs e)
        {
            addTask.Width -= 10;
            addTask.Height -= 10;
            addTask.Margin = new Thickness(0);
            TasksSuggestionsInput.Margin = new Thickness(10, 0, 0, -0.5);
        }

        private void addTask_MouseEnter(object sender, MouseEventArgs e)
        {
            addTask.Width += 10;
            addTask.Height += 10;
            addTask.Margin = new Thickness(-5, -5, 0, 0);
            TasksSuggestionsInput.Margin = new Thickness(5, 0, 0, -0.5);
        }

        private async void addTask_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TasksInput.Text) || TasksInput.Text == "Today tasks")
            {
                return;
            }
            var todayPlan = new TodayPlan
            {
                Task = TasksInput.Text,
                IsRoutine = false,
                IsAdded = true,
                UserId = _currentUser.Id
            };
            _context.TodayPlans.Add(todayPlan);
            await _context.SaveChangesAsync();

            Refresh();

            TasksInput.Text = "Today tasks";
            TasksInput.Foreground = Brushes.Gray;
        }

        private void deleteItem1_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Button).Width += 10;
            (sender as Button).Height += 10;
            (sender as Button).Margin = new Thickness(-5, -5, 0, 0);
        }

        private void TasksSuggestionsInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TasksSuggestionsInput.Text == "Routine tasks")
            {
                TasksSuggestionsInput.Text = "";
                TasksSuggestionsInput.Foreground = Brushes.Black;
            }
        }

        private void TasksSuggestionsInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TasksSuggestionsInput.Text == "")
            {
                TasksSuggestionsInput.Text = "Routine tasks";
                TasksSuggestionsInput.Foreground = Brushes.Gray;
            }
        }

        private void TasksInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TasksInput.Text == "Today tasks")
            {
                TasksInput.Text = "";
                TasksInput.Foreground = Brushes.Black;
            }
        }

        private void TasksInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TasksInput.Text == "")
            {
                TasksInput.Text = "Today tasks";
                TasksInput.Foreground = Brushes.Gray;
            }
        }

        private void TasksSuggestionsInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 14)
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, 14);
            }
            (sender as TextBox).CaretIndex = 14;
        }

        private void TasksInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 14)
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, 14);
            }
            (sender as TextBox).CaretIndex = 14;
        }
    }
}
