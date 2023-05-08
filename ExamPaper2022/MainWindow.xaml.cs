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

namespace ExamPaper2022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<RentalProperty> list = new List<RentalProperty>();
            PropertyData db = new PropertyData();
            var query = from a in db.Properties
                        orderby a.Price
                        select a;
            list = query.ToList();
            propertiesListBox.ItemsSource = list;
        }

        private void propertiesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = propertiesListBox.SelectedItem.ToString();
            PropertyData db = new PropertyData();
            var query = from a in db.Properties
                        where a.Location + " " + a.Price == selectedItem
                        select a.Description;

            textDisplay.Text = query.ToList()[0].ToString();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
        }
    }
}
