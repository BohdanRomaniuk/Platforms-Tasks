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
using Taxi_Driver_WPF.IOTypes;

namespace _4._1__Taxi_Driver_WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private TaxiDriver currentDriver;
		private ClientsDB clientsInfo;
        private DriversDB driversInfo;
        private OrdersDB ordersInfo;
		public MainWindow()
		{
			InitializeComponent();
			clientsInfo = new ClientsDB("../../InputData/ClientsData.txt");
			clientsInfo.ReadFromFile();

			driversInfo = new DriversDB("../../InputData/DriversData.txt");
			driversInfo.ReadFromFile();

			//orders.Items.Add(new TaxiOrder1 { UserName = "Bohdan", PhoneNumber="+380968159669", Dispatch="Городоцька", Destination="Шевченка", Time=190});
			//orders.Items.Add(new TaxiOrder1 { UserName = "Modest", PhoneNumber = "+380968159669", Dispatch = "Городоцька", Destination = "Шевченка", Time = 190 });
		}

		private void startWork_Click(object sender, RoutedEventArgs e)
		{
			currentDriver = driversInfo.FindDriver(driverSurName.Text, driverUserName.Text);
			driverInfoSurnameNameDetails.Content = currentDriver.Surname +" "+ currentDriver.Name;
			driverInfoAgeDetails.Content = currentDriver.Age;
			driverInfoCarDetails.Content = currentDriver.CarNumber;
			driverInfoExpDetails.Content = currentDriver.Experience;
			driverInfoCostDetails.Content = currentDriver.PayCheck;
			driverInfoCostPerMinDetails.Content = currentDriver.CostPerMinute;

			ordersInfo = new OrdersDB("../../InputData/OrdersData.txt", clientsInfo, driversInfo, currentDriver);
			ordersInfo.ReadFromFile();
			foreach(TaxiOrder order in ordersInfo.AllOrders)
			{

			}
		}

		private void endOfWork_Click(object sender, RoutedEventArgs e)
		{

		}

		private void orders_Click(object sender, RoutedEventArgs e)
		{
			var item = (sender as ListView).SelectedItem;
			if (item != null)
			{
				MessageBox.Show((item as TaxiOrder1).UserName);
				OrderWindow wind = new OrderWindow();
				wind.Show();
			}
		}
	}
	class TaxiOrder1
	{
		public string UserName { get; set; }
		public string PhoneNumber { get; set; }
		public string Dispatch { get; set; }
		public string Destination { get; set; }
		public uint Time { get; set; }
	}
}
