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
            TasksList.ItemsSource = _context.TodayPlans.Local.ToBindingList().Where(p => p.IsAdded == true && p.UserId == _currentUser.Id);

            TaskListRoutine.ItemsSource = null;
            TaskListRoutine.ItemsSource = _context.TodayPlans.Local.ToBindingList().Where(p => p.IsRoutine == true && p.UserId == _currentUser.Id);
        }

        public Diary(FamilyOrganizerContext familyOrganizerContext, AppUser currentUser)
        {
            InitializeComponent();
            _context = familyOrganizerContext;
            _currentUser = currentUser;

            TaskListRoutine.ItemsSource = _context.TodayPlans.Local.ToBindingList().Where(p => p.IsRoutine == true && p.UserId == _currentUser.Id);
            TasksList.ItemsSource = _context.TodayPlans.Local.ToBindingList().Where(p => p.IsAdded == true && p.UserId == _currentUser.Id);
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

        private void deleteItem_Click(object sender, RoutedEventArgs e)
        {
            var todayPlan = (sender as Button).DataContext as TodayPlan;

            _context.TodayPlans.Remove(todayPlan);
            _context.SaveChanges();

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

        private void approveItem_Click(object sender, RoutedEventArgs e)
        {
            var todayPlan = (sender as Button).DataContext as TodayPlan;
            todayPlan.IsAdded = true;
            _context.Entry(todayPlan).State = EntityState.Modified;
            _context.SaveChanges();
            Refresh();
        }

        private void deleteItem1_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Button).Width -= 10;
            (sender as Button).Height -= 10;
            (sender as Button).Margin = new Thickness(0, 0, 0, 0);
        }

        private void deleteItem1_Click(object sender, RoutedEventArgs e)
        {
            var todayPlan = (sender as Button).DataContext as TodayPlan;
            
            if(todayPlan.IsRoutine)
            {
                todayPlan.IsAdded = false;
                _context.Entry(todayPlan).State = EntityState.Modified;
            }
            else
            {
                _context.TodayPlans.Remove(todayPlan);
            }
            _context.SaveChanges();

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

        private void addTaskSuggestion_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TasksSuggestionsInput.Text))
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
            _context.SaveChanges();

            Refresh();

            TasksSuggestionsInput.Text = "";
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

        private void addTask_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TasksInput.Text))
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
            _context.SaveChanges();

            Refresh();

            TasksInput.Text = "";
        }

        private void deleteItem1_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Button).Width += 10;
            (sender as Button).Height += 10;
            (sender as Button).Margin = new Thickness(-5, -5, 0, 0);
        }

        private void TasksInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 19)
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, 19);
            }
            (sender as TextBox).CaretIndex = 19;
        }

    }
}
