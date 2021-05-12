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
using FamilyOrganizer.DB;
using FamilyOrganizer.User;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace FamilyOrganizer
{
    /// <summary>
    /// Логика взаимодействия для Statistics.xaml
    /// </summary>
    public partial class Statistics : UserControl
    {
        private readonly FamilyOrganizerContext _context;
        private readonly AppUser _currentUser;  

        public void PieChart()
        {
            var month = (int)(MonthComboBox.SelectedItem ?? 0);
            var year = (int)(YearComboBox.SelectedItem ?? 0);

            var transactions = _context.Transactions.Where(t => t.Date.Month == month
                && t.Date.Year == year);

            var foodCollection = transactions.Where(t => t.Type == "Food");
            var food = foodCollection.Count() == 0 ? 0 : foodCollection.Sum(t => Math.Abs(t.Sum));

            var transportCollection = transactions.Where(t => t.Type == "Transport");
            var transport = transportCollection.Count() == 0 ? 0 : transportCollection.Sum(t => Math.Abs(t.Sum));

            var educationCollection = transactions.Where(t => t.Type == "Education");
            var education = educationCollection.Count() == 0 ? 0 
                : educationCollection.Sum(t => Math.Abs(t.Sum));

            var entertainmentCollection = transactions.Where(t => t.Type == "Entertainment");
            var entertainment = entertainmentCollection.Count() == 0 ? 0 
                : entertainmentCollection.Sum(t => Math.Abs(t.Sum));


            var otherCollection = transactions.Where(t => t.Type == "Other");
            var other = otherCollection.Count() == 0 ? 0 : otherCollection.Sum(t => Math.Abs(t.Sum));

            var foodValues = new ChartValues<double>();
            foodValues.Add(food);
            Food.Values = foodValues;

            var transportValues = new ChartValues<double>();
            transportValues.Add(transport);
            Transport.Values = transportValues;

            var educationValues = new ChartValues<double>();
            educationValues.Add(education);
            Education.Values = educationValues;

            var entertainmentValues = new ChartValues<double>();
            entertainmentValues.Add(entertainment);
            Entertainment.Values = entertainmentValues;

            var otherValues = new ChartValues<double>();
            otherValues.Add(other);
            Other.Values = otherValues;

            var a = Pie.DataTooltip.Content;
        }

        public void Chart()
        {
            var month = (int)(MonthComboBox.SelectedItem ?? 0);
            var year = (int)(YearComboBox.SelectedItem ?? 0);

            var balances = _context.Balances.Where(b => b.Date.Month == month && b.Date.Year == year)
               .OrderBy(b => b.Date);

            var balancesChart = new ChartValues<Point>();

            foreach (var balance in balances)
            {
                var point = new Point() { X = balance.Date.Day, Y = balance.CurrentBalance };
                balancesChart.Add(point);
            }

            Values1.Title = "Family balance";
            Values1.Configuration = new CartesianMapper<Point>()
                .X(point => point.X)
                .Y(point => point.Y);


            Values1.Values = balancesChart;
        }

        public Statistics()
        {
            InitializeComponent();
        }

        public Statistics(FamilyOrganizerContext familyOrganizerContext, AppUser currentUser)
        {
            InitializeComponent();

            _context = familyOrganizerContext;
            _currentUser = currentUser;

            YearComboBox.ItemsSource = _context.Balances.Select(b => b.Date.Year).Distinct()
                .ToList();

            MonthComboBox.ItemsSource = _context.Balances.Select(b => b.Date.Month).Distinct()
                .ToList();

            YearComboBox.SelectedIndex = 0;
            MonthComboBox.SelectedIndex = 0;

            Chart();

            PieChart();

            DataContext = this;
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void DateSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Chart();
            PieChart();
        }

    }
}
