using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Taxi_Driver_WPF.DataTypes;

namespace Taxi_Driver_WPF.IOTypes
{
	class OrdersDB
	{
		private string fileName;
		private List<TaxiOrder> allOrders;
		private ClientsDB clientsInfo;
		private DriversDB driversInfo;
		private TaxiDriver currentDriver;
		public List<TaxiOrder> AllOrders
		{
			get
			{
				return allOrders;
			}
			set
			{
				if(value.Count==0)
				{
					throw new ArgumentOutOfRangeException("Orders are empty");
				}
				allOrders = value;
			}
		}
		public OrdersDB(string _fileName, ClientsDB _clientsInfo, DriversDB _driversInfo, TaxiDriver _currentDriver)
		{
			allOrders = new List<TaxiOrder>();
			fileName = _fileName;
			clientsInfo = _clientsInfo;
			driversInfo = _driversInfo;
			currentDriver = _currentDriver;
		}
		public void ReadFromFile()
		{
			string[] allLines = File.ReadAllLines(fileName);
			foreach (string line in allLines)
			{
				string[] lineElems = line.Split(' ');
				if(Convert.ToUInt32(lineElems[1])==currentDriver.Id)
				{
					allOrders.Add(new TaxiOrder(clientsInfo.GetClientById(Convert.ToUInt32(lineElems[0])), currentDriver, DateTime.Parse(lineElems[2]), lineElems[3], lineElems[4], Convert.ToUInt32(lineElems[5]), Convert.ToUInt32(lineElems[6]), Convert.ToBoolean(lineElems[7])));
				}
			}
		}
		public void WriteToFile()
		{
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				foreach(TaxiOrder order in allOrders)
				{
					writer.WriteLine(order);
                }
			}
		}
	}
}
