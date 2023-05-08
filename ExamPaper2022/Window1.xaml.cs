using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace ExamPaper2022
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            RentalType typeOfRental = new RentalType();
            string typeOfRentalString = typeOfRentalComboBox.SelectedItem.ToString();
            string location;
            decimal price = 0;
            string description;
            string image = "";
            if (typeOfRentalComboBox.SelectedItem == null)
            {
                MessageBox.Show("Must input a value for Type of Rental!");
            }
            else if (locationTextBox.Text == null || locationTextBox.Text == "")
            {
                MessageBox.Show("Must input a value for Location!");
            }
            else if (priceTextBox.Text == null || priceTextBox.Text == "")
            {
                MessageBox.Show("Must input a value for Price!");
            }
            else if (descriptionTextBox.Text == null || descriptionTextBox.Text == "")
            {
                MessageBox.Show("Must input a value for Description!");
            }
            else
            {
                //getting value for typeOfRental
                if (typeOfRentalString.Contains("House"))
                {
                    typeOfRental = RentalType.House; 
                    image = "imgs/house.jpg";
                }
                else if (typeOfRentalString.Contains("Flat"))
                {
                    typeOfRental = RentalType.Flat; 
                    image = "imgs/apartment.png";
                }
                else
                {
                    typeOfRental = RentalType.Share; 
                    image = "imgs/people.png";
                }
                //getting location
                location = locationTextBox.Text;
                //getting price
                try
                {
                    price = decimal.Parse(priceTextBox.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex + "\n\nPlease enter a numeric value for price");
                }
                //getting description
                description = descriptionTextBox.Text;

                //write to database
                PropertyData db = new PropertyData();
                RentalProperty newProperty = new RentalProperty()
                {
                    Price = price,
                    Image = image,
                    RentalType = typeOfRental,
                    Description = description,
                    Location = location
                };
                db.Properties.Add(newProperty);
                db.SaveChanges();
                MessageBox.Show("Property Added to Database!");
            }
        }
    }
}
