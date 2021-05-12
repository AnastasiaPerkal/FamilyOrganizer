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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly FamilyOrganizerContext _context;
        private readonly AppUser _currentUser;

        public string GetPath(string path)
        {
            return path.Insert(path.Length - 4, "1");
        }
        public string GetPathBack(string path)
        {
            return path.Remove(path.Length - 5, 1);
        }

        public void SetWhiteImg(Image Img)
        {
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(GetPath(Img.Source.ToString()), UriKind.Absolute);
            img.EndInit();
            Img.Source = img;
        }
        public void SetImg(Image Img)
        {
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(GetPathBack(Img.Source.ToString()), UriKind.Absolute);
            img.EndInit();
            Img.Source = img;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(FamilyOrganizerContext familyOrganizerContext, AppUser currentUser)
        {
            InitializeComponent();

            _context = familyOrganizerContext;
            _currentUser = currentUser;
            DataContext = _context.AppUsers.Local.ToBindingList();

            LV.SelectedIndex = 0;

            if (_currentUser.Role != "Parent")
            {
                FamilyTab.Visibility = Visibility.Collapsed;
                StatsTab.Visibility = Visibility.Collapsed;
            }
        }

        

        private void ToggleBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            //Back.Backgroun
   
        }

        private void ToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            //Back.Background.Opacity = 0.5;
        }

        private void BG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ToggleBtn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void generalImage_MouseEnter(object sender, MouseEventArgs e)
        {
            SetWhiteImg(generalImage);
        }

        private void generalImage_MouseLeave(object sender, MouseEventArgs e)
        {
            SetImg(generalImage);
        }
    
        private void profileImage_MouseEnter(object sender, MouseEventArgs e)
        {
            SetWhiteImg(profileImage);
        }

        private void profileImage_MouseLeave(object sender, MouseEventArgs e)
        {
            SetImg(profileImage);
        }

        private void familyImage_MouseEnter(object sender, MouseEventArgs e)
        {
            SetWhiteImg(familyImage);
        }

        private void familyImage_MouseLeave(object sender, MouseEventArgs e)
        {
            SetImg(familyImage);
        }

        private void statisticsImage_MouseEnter(object sender, MouseEventArgs e)
        {
            SetWhiteImg(statisticsImage);
        }

        private void statisticsImage_MouseLeave(object sender, MouseEventArgs e)
        {
            SetImg(statisticsImage);
        }

        private void expencesImage_MouseEnter(object sender, MouseEventArgs e)
        {
            SetWhiteImg(expencesImage);
        }

        private void expencesImage_MouseLeave(object sender, MouseEventArgs e)
        {
            SetImg(expencesImage);
        }

        private void listImage_MouseEnter(object sender, MouseEventArgs e)
        {
            SetWhiteImg(listImage);
        }

        private void listImage_MouseLeave(object sender, MouseEventArgs e)
        {
            SetImg(listImage);
        }

        private void diaryImage_MouseEnter(object sender, MouseEventArgs e)
        {
            SetWhiteImg(diaryImage);
        }

        private void diaryImage_MouseLeave(object sender, MouseEventArgs e)
        {
            SetImg(diaryImage);
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

        private void LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var bc = new BrushConverter();

            switch (LV.SelectedIndex)
            {
                case 0:
                    Back1.Children.Clear();
                    Back1.Children.Add(new General(_context, _currentUser));
                    NavigationPnl.Background = (Brush)bc.ConvertFrom("#c7cedf");
                    break;
                case 1:
                    Back1.Children.Clear();
                    Back1.Children.Add(new Edit(_context, _currentUser));
                    NavigationPnl.Background = (Brush)bc.ConvertFrom("#c7dfd5");
                    break;
                case 2:
                    Back1.Children.Clear();
                    Back1.Children.Add(new Family(_context, _currentUser));
                    NavigationPnl.Background = (Brush)bc.ConvertFrom("#c7dfd5");
                    break;
                case 3:
                    Back1.Children.Clear();
                    Back1.Children.Add(new Statistics(_context, _currentUser));
                    NavigationPnl.Background = (Brush)bc.ConvertFrom("#bddeb4");
                    break;
                case 4:
                    Back1.Children.Clear();
                    Back1.Children.Add(new Money(_context, _currentUser));
                    NavigationPnl.Background = (Brush)bc.ConvertFrom("#bddeb4");
                    break;
                case 5:
                    Back1.Children.Clear();
                    Back1.Children.Add(new ShoppingList(_context, _currentUser));
                    NavigationPnl.Background = (Brush)bc.ConvertFrom("#f0ccfc");
                    break;
                case 6:
                    Back1.Children.Clear();
                    Back1.Children.Add(new Diary());
                    NavigationPnl.Background = (Brush)bc.ConvertFrom("#fcd8cc");
                    break;
                default:
                    break;
            }
        }

        private void LogoutBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            LogoutBtn.Width += 10;
            LogoutBtn.Height += 10;
            LogoutBtn.Margin = new Thickness(-5, -5, 0, 0);
        }

        private void LogoutBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            LogoutBtn.Width -= 10;
            LogoutBtn.Height -= 10;
            LogoutBtn.Margin = new Thickness(0);
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login(_context);
            l.Show();

            Close();
        }


    }
}
