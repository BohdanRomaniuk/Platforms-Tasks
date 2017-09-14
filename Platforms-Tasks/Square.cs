using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace LNU.AMI33.Rommaniuk.Variant1
{
	[Serializable]
	public sealed class Square : Figure, IShape, IFileManager<Square>
	{
		private Point leftTop;
		private Point rightBottom;
		public Point LeftTop
		{
			get
			{
				return leftTop;
			}
			set
			{
				leftTop = value;
			}
		}
		public Point RightBottom
		{
			get
			{
				return rightBottom;
			}
			set
			{
				if (value.X < leftTop.X || value.Y > leftTop.Y)
				{
					throw new ArgumentOutOfRangeException(String.Format("Point ({0},{1}) is not RIGHT BOTTOM from left top point!", value.X, value.Y));
				}
				rightBottom = value;
			}
		}
		public Square()
		{
		}
		public Square(Point _leftTop, Point _rightBottom)
		{
			try
			{
				LeftTop = _leftTop;
				RightBottom = _rightBottom;
			}
			catch (ArgumentOutOfRangeException squareExcept)
			{
				Console.WriteLine("Error occured while creating Square! {0}", squareExcept);
			}
		}
		public override double CalculatePerimeter()
		{
			return 2 * (rightBottom.X - leftTop.X + leftTop.Y - rightBottom.Y);
		}
		public override double CalculateSquare()
		{
			return (rightBottom.X - leftTop.X) * (leftTop.Y - rightBottom.Y);
		}
		public List<Square> ReadFromFile(string fileName)
		{
			XmlSerializer deserializer = new XmlSerializer(typeof(List<Square>));
			List<Square> deserializedList;
			using (XmlReader reader = XmlReader.Create(fileName))
			{
				deserializedList = (List<Square>)deserializer.Deserialize(reader);
			}
			return deserializedList;
		}
		public void WriteToFile(List<Square> outputData, string fileName)
		{
			using (Stream outputFile = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Square>));
				serializer.Serialize(outputFile, outputData);
			}
		}
		public override bool IsInThirdQuarter()
		{
			return IsBottomPointInThirdQuarter() && IsLeftPointInThirdQuarter();
		}
		private bool IsBottomPointInThirdQuarter()
		{
			return RightBottom.X < 0 && RightBottom.Y < 0;
		}
		private bool IsLeftPointInThirdQuarter()
		{
			return LeftTop.X < 0 && LeftTop.Y < 0;
		}
		public override string ToString()
		{
			return String.Format("Square: left top={0}, right bottom={1}", LeftTop, RightBottom);
		}
	}
}
