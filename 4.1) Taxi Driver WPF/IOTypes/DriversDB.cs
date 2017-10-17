using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Taxi_Driver_WPF.DataTypes;

namespace Taxi_Driver_WPF.IOTypes
{
	class DriversDB
	{
		private List<TaxiDriver> allDrivers;
		public List<TaxiDriver> AllDrivers
		{
			get
			{
				return allDrivers;
			}
		}
		public DriversDB()
		{
			allDrivers = new List<TaxiDriver>();
		}

		public void ReadFromFile(string fileName)
		{
			string[] allLines = File.ReadAllLines(fileName);
			foreach (string line in allLines)
			{
				string[] lineElems = line.Split(' ');
				allDrivers.Add(new TaxiDriver(Convert.ToUInt32(lineElems[0]), lineElems[1], lineElems[2], Convert.ToUInt32(lineElems[3]), lineElems[4], Convert.ToUInt32(lineElems[5]), Convert.ToUInt32(lineElems[6]), Convert.ToDouble(lineElems[7])));
			}
		}

		public void WriteToFile(string fileName)
		{
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				foreach(TaxiDriver driver in allDrivers)
				{
					writer.WriteLine(driver);
				}
			}
		}

		public TaxiDriver FindDriver(string surname, string name)
		{
			TaxiDriver searchResult = new TaxiDriver();
			foreach(TaxiDriver driver in allDrivers)
			{
				if(driver.Surname==surname && driver.Name==name)
				{
					searchResult = driver;
					break;
				}
			}
			return searchResult;
		}

		public bool UpdateDriverInfo(string surname, string name, TaxiDriver newInfo)
		{
			bool updatedSuccesfully = false;
			foreach (TaxiDriver driver in allDrivers)
			{
				if (driver.Surname == surname && driver.Name == name)
				{
					//driver = newInfo;
					updatedSuccesfully = true;
					break;
				}
			}
			return updatedSuccesfully;
		}
	}
}
