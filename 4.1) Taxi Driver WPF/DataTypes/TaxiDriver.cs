using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi_Driver_WPF.DataTypes
{
	class TaxiDriver
	{
		private string surname;
		private string name;
		private uint age;
		private string carNumber;
		private uint experience;
		private uint costPerMinute;
		private double payCheck;
		public string Surname
		{
			get
			{
				return surname;
			}
			set
			{
				if(String.IsNullOrEmpty(value))
				{
					throw new ArgumentOutOfRangeException("Drive surname cant be empty");
				}
				surname = value;
			}
		}
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				if (String.IsNullOrEmpty(value))
				{
					throw new ArgumentOutOfRangeException("Drive name cant be empty");
				}
				name = value;
			}
		}
		public uint Age
		{
			get
			{
				return age;
			}
			set
			{
				if (value < 18)
				{
					throw new ArgumentOutOfRangeException("Driver is too young!");
				}
				age = value;
			}
		}
		public string CarNumber
		{
			get
			{
				return carNumber;
			}
			set
			{
				if(String.IsNullOrEmpty(value))
				{
					throw new ArgumentOutOfRangeException("Car Number cant be empty");
				}
				carNumber = value;
			}
		}
		public uint Experience
		{
			get
			{
				return experience;
			}
			set
			{
				if (value < 2)
				{
					throw new ArgumentOutOfRangeException("Drive has a small experience");
				}
				experience = value;
			}
		}
		public uint CostPerMinute
		{
			get
			{
				return costPerMinute;
			}
			set
			{
				if(value<=0)
				{
					throw new ArgumentOutOfRangeException("Cost per minute cant be less then 0");
				}
				costPerMinute = value;
			}
		}
		public double PayCheck
		{
			get
			{
				return payCheck;
			}
			set
			{
				if(value<0)
				{
					throw new ArgumentOutOfRangeException("PayCheck cnat be < than 0");
				}
				payCheck = value;
			}
		}
		public TaxiDriver()
		{
			PayCheck = 0;
		}
		public TaxiDriver(string _surname, string _name, uint _age, string _carNumber, uint _experience, uint _cost)
		{
			Surname = _surname;
			Name = _name;
			Age = _age;
			CarNumber = _carNumber;
			Experience = _experience;
			CostPerMinute = _cost;
			PayCheck = 0;
		}
		public static TaxiDriver findDriver(List<TaxiDriver> allDrivers, string _surname, string _name)
		{
			TaxiDriver searchResult = new TaxiDriver();
			foreach(TaxiDriver driver in allDrivers)
			{
				if (driver.Surname == _surname && driver.Name == _name)
				{
					searchResult = driver;
				}
			}
			return searchResult;
		}
		public override string ToString()
		{
			return String.Format("Surname: {0,-10} Name: {1,-10} Age: {2,-10} Exp: {3,-10}", Surname, Name, Age, Experience);
		}
	}
}
