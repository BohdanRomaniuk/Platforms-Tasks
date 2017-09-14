using System;
using System.Xml.Serialization;

namespace LNU.AMI33.Rommaniuk.Variant1
{
	[Serializable]
	[XmlInclude(typeof(Circle))]
	[XmlInclude(typeof(Square))]
	public abstract class Figure : IShape
	{
		public Figure()
		{
		}
		public abstract double CalculatePerimeter();
		public abstract double CalculateSquare();
		public abstract bool IsInThirdQuarter();
	}
}
