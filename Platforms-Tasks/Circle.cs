using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace LNU.AMI33.Rommaniuk.Variant1
{
	public sealed class Circle : Figure, IShape, IFileManager<Circle>
	{
		private Point center;
		private double radius;
		public Point Center
		{
			get
			{
				return center;
			}
			set
			{
				center = value;
			}
		}
		public double Radius
		{
			get
			{
				return radius;
			}
			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("Radius cant be less equal then zero!");
				}
				radius = value;
			}
		}
		public Circle()
		{
		}
		public Circle(Point _center, double _radius)
		{
			try
			{
				Center = _center;
				Radius = _radius;
			}
			catch (ArgumentOutOfRangeException circleExcept)
			{
				Console.WriteLine("Error occured while creating Circle! {0}", circleExcept);
			}
		}
		public override double CalculatePerimeter()
		{
			return 2 * Math.PI * Radius;
		}
		public override double CalculateSquare()
		{
			return Math.PI * Math.Pow(Radius, 2);
		}
		public List<Circle> ReadFromFile(string fileName)
		{
			XmlSerializer deserializer = new XmlSerializer(typeof(List<Square>));
			List<Circle> deserializedList;
			using (XmlReader reader = XmlReader.Create(fileName))
			{
				deserializedList = (List<Circle>)deserializer.Deserialize(reader);
			}
			return deserializedList;
		}
		public void WriteToFile(List<Circle> outputData, string fileName)
		{
			using (Stream outputFile = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Circle>));
				serializer.Serialize(outputFile, outputData);
			}
		}
		public override bool IsInThirdQuarter()
		{
			return (Center.X + radius < 0) && (Center.Y + radius < 0);
		}
		public override string ToString()
		{
			return String.Format("Circle: center={0}, radius={1}", Center, Radius);
		}
	}

}
