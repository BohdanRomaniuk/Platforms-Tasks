using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi_Driver_Console.Types
{
	class TaxiDriver
	{
		private string surname;
		private string name;
		private uint age;
		private uint experience;
		public string Surname
		{
			get
			{
				return surname;
			}
			set
			{
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
				if(age<18)
				{
					throw new ArgumentOutOfRangeException("Driver is too young!");
				}
				age = value;
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
				if(experience<4)
				{
					throw new ArgumentOutOfRangeException("Drive has a small experience");
				}
				experience = value;
			}
		}
		public TaxiDriver()
		{
		}
		public TaxiDriver(string _surname, string _name, uint _age, uint _experience)
		{
			Surname = _surname;
			Name = _name;
			Age = _age;
			Experience = _experience;
		}
		public override string ToString()
		{
			return String.Format("Surname: {0,-10} Name: {1,-10} Age: {2,-10} Exp: {3,-10}", Surname, Name, Age, Experience);
		}
	}
}
