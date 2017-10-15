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

namespace _4._1__Taxi_Driver_WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			orders.Items.Add(new TaxiOrder { UserName = "Bohdan", PhoneNumber="+380968159669", Dispatch="Городоцька", Destination="Шевченка", Time=190});
		}

		private void startWork_Click(object sender, RoutedEventArgs e)
		{

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
