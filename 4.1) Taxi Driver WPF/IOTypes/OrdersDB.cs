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
		private List<TaxiOrder> allOrders;
		private ClientsDB clientsInfo;
		private DriversDB driversInfo;
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
		public OrdersDB(string _fileNameList, ClientsDB _clientsInfo, DriversDB _driversInfo)
		{
			allOrders = new List<TaxiOrder>();
			clientsInfo = _clientsInfo;
			driversInfo = _driversInfo;
		}
		public void ReadFromFile(string fileName)
		{
			string[] allLines = File.ReadAllLines(fileName);
			foreach (string line in allLines)
			{
				string[] lineElems = line.Split(' ');
				allOrders.Add(new TaxiOrder(Convert.ToUInt32(lineElems[0]), lineElems[1], lineElems[2], Convert.ToUInt32(lineElems[3]), lineElems[4], Convert.ToUInt32(lineElems[5]), Convert.ToUInt32(lineElems[6]), Convert.ToDouble(lineElems[7])));
			}
		}
		public void WriteToFile()
		{

		}
	}
}
