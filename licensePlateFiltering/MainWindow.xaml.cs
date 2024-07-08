using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace licensePlateFiltering
{
    public partial class MainWindow : Window
    {
        private List<CarInfo> carInfoList = new List<CarInfo>
        {
            new CarInfo { LicensePlate = "UV90 WXY", IsOwned = true, CarBrandID = 1 },
            new CarInfo { LicensePlate = "AB12 CDE", IsOwned = true, CarBrandID = 2 },
            new CarInfo { LicensePlate = "PQ78 RST", IsOwned = false, CarBrandID = 1 },
            new CarInfo { LicensePlate = "EF22 GHI", IsOwned = true, CarBrandID = 3 },
            new CarInfo { LicensePlate = "ZA11 BCD", IsOwned = false, CarBrandID = 2 },
            new CarInfo { LicensePlate = "OP44 QRS", IsOwned = true, CarBrandID = 1 }
        };


        public MainWindow()
        {
            InitializeComponent();
            PopulateUnsortedPlates();
            SortOrderComboBox.SelectedIndex = 0; // Default to Ascending
        }

        private void PopulateUnsortedPlates()
        {
            txtBlockCarLicenses.Text = "Car Licenses Unsorted:";
            foreach (CarInfo car in carInfoList)
            {
                string ownership = car.IsOwned ? "Owned" : "Not Owned";
                txtBlockCarLicenses.Text += $"\n{car.LicensePlate} - {ownership}\nCar Brand ID: {car.CarBrandID}";
            }
        }
        private void SortAlphabetButton_Click(object sender, RoutedEventArgs e)
        {
            bool ascending = (SortOrderComboBox.SelectedIndex == 0);
            List<CarInfo> sortedList;

            if (ascending)
            {
                sortedList = carInfoList.OrderBy(car => car.LicensePlate).ToList();
            }
            else
            {
                sortedList = carInfoList.OrderByDescending(car => car.LicensePlate).ToList();
            }
           
            DisplaySortedPlates(sortedList);
        }

        private void DisplaySortedPlates(List<CarInfo> sortedList)
        {
            SortedPlatesTextBlock.Text = "Alphabetical License:";
            foreach (CarInfo car in sortedList)
            {
                string ownership = car.IsOwned ? "Owned" : "Not Owned";
                SortedPlatesTextBlock.Text += $"\n{car.LicensePlate} - {ownership}\nCar Brand ID: {car.CarBrandID}";
            }
        }
    }
}
