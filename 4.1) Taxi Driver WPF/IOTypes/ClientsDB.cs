using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Taxi_Driver_WPF.DataTypes;

namespace Taxi_Driver_WPF.IOTypes
{
	class ClientsDB
	{
		private List<TaxiClient> allClients;
		public List<TaxiClient> AllClients
		{
			get
			{
				return allClients;
			}
		}
		public ClientsDB()
		{
			allClients = new List<TaxiClient>();
		}

		public void ReadFromFile(string fileName)
		{
			string[] allLines = File.ReadAllLines(fileName);
			foreach(string line in allLines)
			{
				string[] lineElems = line.Split(' ');
				allClients.Add(new TaxiClient(Convert.ToUInt32(lineElems[0]), lineElems[1], lineElems[2]));
			}
		}

		public void WriteToFile(string fileName)
		{
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				foreach(TaxiClient client in allClients)
				{
					writer.WriteLine(client);
				}
			}
		}
	}
}
