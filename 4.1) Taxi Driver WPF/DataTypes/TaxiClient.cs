using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi_Driver_WPF.DataTypes
{
	class TaxiClient
	{
		private string name;
		private string phoneNumber;
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				if(String.IsNullOrEmpty(value))
				{
					throw new ArgumentOutOfRangeException("Name cant be empty");
				}
				name = value;
			}
		}
		public string PhoneNumber
		{
			get
			{
				return phoneNumber;
			}
			set
			{
				if (value.Length < 10 || value.Length > 13)
				{
					throw new ArgumentOutOfRangeException("Phone number is incorrect");
				}
				phoneNumber = value;
			}
		}
		public TaxiClient()
		{
		}
		public TaxiClient(string _name, string _phoneNumber)
		{
			Name = _name;
			PhoneNumber = _phoneNumber;
		}
		public override string ToString()
		{
			return String.Format("Name: {0,-10} Phone Number: {1}", Name, PhoneNumber);
		}
	}
}
