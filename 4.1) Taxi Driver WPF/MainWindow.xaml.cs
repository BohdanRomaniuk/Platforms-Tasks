using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Taxi_Driver_WPF.DataTypes;

namespace _4._1__Taxi_Driver_WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private TaxiDriver currentDriver;
		public MainWindow()
		{
			InitializeComponent();
			orders.Items.Add(new TaxiOrder { UserName = "Bohdan", PhoneNumber="+380968159669", Dispatch="Городоцька", Destination="Шевченка", Time=190});
			orders.Items.Add(new TaxiOrder { UserName = "Modest", PhoneNumber = "+380968159669", Dispatch = "Городоцька", Destination = "Шевченка", Time = 190 });
		}

		private void startWork_Click(object sender, RoutedEventArgs e)
		{
			currentDriver = new TaxiDriver("Паробій", "Роман", 19, "ВС5674АС", 5, 50);
			driverInfoSurnameNameDetails.Content = currentDriver.Surname +" "+ currentDriver.Name;
			driverInfoAgeDetails.Content = currentDriver.Age;
			driverInfoCarDetails.Content = currentDriver.CarNumber;
			driverInfoExpDetails.Content = currentDriver.Experience;
			driverInfoCostDetails.Content = currentDriver.PayCheck;
			driverInfoCostPerMinDetails.Content = currentDriver.CostPerMinute;
        }

		private void endOfWork_Click(object sender, RoutedEventArgs e)
		{

		}

		private void orders_Click(object sender, RoutedEventArgs e)
		{
			var item = (sender as ListView).SelectedItem;
			if (item != null)
			{
				MessageBox.Show((item as TaxiOrder).UserName);
				OrderWindow wind = new OrderWindow();
				wind.Show();
			}
		}
	}
	class TaxiOrder
	{
		public string UserName { get; set; }
		public string PhoneNumber { get; set; }
		public string Dispatch { get; set; }
		public string Destination { get; set; }
		public uint Time { get; set; }
	}
}
