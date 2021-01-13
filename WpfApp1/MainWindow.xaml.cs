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
using WpfApp1.Core;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Car> cars;
        JsonHandler jsonHandler = new JsonHandler();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {

                cars = jsonHandler.Read();
                listViewCars.ItemsSource = cars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            Car newCar = new Car()
            {
                HorsePower = TextBoxHorsePower.Text,
                IsElectricy = CheckBoxElectrical.IsChecked.Value ? "Ja" : "Nej",
                LicenseNumber = TextBoxLicenseNumber.Text,
                Model = TextBoxModel.Text,
                Weight = TextBoxWeight.Text
            };
            cars.Add(newCar);
            jsonHandler.Write(cars);
            listViewCars.Items.Refresh();
        }

        private void DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            cars.RemoveAt(listViewCars.SelectedIndex);
            jsonHandler.Write(cars);
            listViewCars.Items.Refresh();
        }

        private void RegNumBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
