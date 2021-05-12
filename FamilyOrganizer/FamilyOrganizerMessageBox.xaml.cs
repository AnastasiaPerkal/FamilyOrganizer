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
using System.Windows.Shapes;

namespace FamilyOrganizer
{
    /// <summary>
    /// Логика взаимодействия для FamilyOrganizerMessageBox.xaml
    /// </summary>
    public partial class FamilyOrganizerMessageBox : Window
    {
        public FamilyOrganizerMessageBox()
        {
            InitializeComponent();
        }
        public FamilyOrganizerMessageBox(string message)
        {
            InitializeComponent();
            MessageBoxLabel.Content = message;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CloseBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            CloseBtn.Width += 10;
            CloseBtn.Height += 10;
            CloseBtn.Margin = new Thickness(5, 5, 10, 10);
        }

        private void CloseBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            CloseBtn.Width -= 10;
            CloseBtn.Height -= 10;
            CloseBtn.Margin = new Thickness(10, 10, 10, 10);
        }
    }
}
