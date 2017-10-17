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
using System.Windows.Shapes;
using Taxi_Driver_WPF.DataTypes;

namespace _4._1__Taxi_Driver_WPF
{
	/// <summary>
	/// Interaction logic for OrderWindow.xaml
	/// </summary>
	public partial class OrderWindow : Window
	{
		private TaxiOrder currentOrder;
		public OrderWindow(TaxiOrder _currentOrder)
		{
			InitializeComponent();
			currentOrder = _currentOrder;
			clientNameDesc.Content = currentOrder.Client.Name;
			clientPhoneDesc.Content = currentOrder.Client.PhoneNumber;
			clientFromDesc.Content = currentOrder.Dispatch;
			clientToDesc.Content = currentOrder.Destination;
			clientTimeDesc.Content = currentOrder.ArriveTime;
        }
		private void startRoad_Click(object sender, RoutedEventArgs e)
		{

		}
		private void endRoad_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
