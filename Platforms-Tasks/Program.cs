using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LNU.AMI33.Rommaniuk.Variant1
{
	interface IShape
	{
		double CalculatePerimeter();
		double CalculateSquare();
	}
	interface IFileManager
	{
		void ReadFromFile(StreamReader reader);
		void WriteToFile(string fileName);
	}
	struct Point
	{
		public int x;
		public int y;
		public Point(int _x, int _y)
		{
			x = _x;
			y = _y;
		}
		public override string ToString()
		{
			return String.Format("({0},{1})", x, y);
		}
	}

	class Circle : IShape, IFileManager
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
			Center = _center;
			Radius = _radius;
		}
		public double CalculatePerimeter()
		{
			return 2 * Math.PI * Radius;
		}
		public double CalculateSquare()
		{
			return Math.PI * Math.Pow(Radius, 2);
		}
		public void ReadFromFile(StreamReader reader)
		{

		}
		public void WriteToFile(string fileName)
		{
			throw new NotImplementedException();
		}
		public override string ToString()
		{
			return String.Format("Circle: center={0}, radius={1}", Center, Radius);
		}
	}
	class Square : IShape, IFileManager
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
				if (value.x < leftTop.x || value.y > leftTop.y)
				{
					throw new ArgumentOutOfRangeException(String.Format("Point ({0},{1}) is not RIGHT BOTTOM from left top point!", value.x, value.y));
				}
				rightBottom = value;
			}
		}
		public Square()
		{
		}
		public Square(Point _leftTop, Point _rightBottom)
		{
			LeftTop = _leftTop;
			RightBottom = _rightBottom;
		}
		public double CalculatePerimeter()
		{
			return 2 * (rightBottom.x - leftTop.x + leftTop.y - rightBottom.y);
		}
		public double CalculateSquare()
		{
			return (rightBottom.x - leftTop.x) * (leftTop.y - rightBottom.y);
		}
		public void ReadFromFile(StreamReader reader)
		{
			throw new NotImplementedException();
		}
		public void WriteToFile(string fileName)
		{
			throw new NotImplementedException();
		}
		public override string ToString()
		{
			return String.Format("Square: left top={0}, right bottom={1}", LeftTop, RightBottom);
		}
	}
	public class MainProgram
	{
		static void Main(string[] args)
		{
			List<IShape> dataFromFile = new List<IShape>();
			string inputFileName = "../../Input.txt";
			if (!File.Exists(inputFileName))
			{
				throw new FileNotFoundException(String.Format("File {0} not found!", inputFileName.Replace("../../", String.Empty)));
			}
			string[] fileLines = File.ReadAllLines(inputFileName);
			if (fileLines.Length == 0)
			{
				throw new FileLoadException(String.Format("File {0} is empty!", inputFileName.Replace("../../", String.Empty)));
			}

			for (uint i = 0; i < fileLines.Length; ++i)
			{
				string[] arr = fileLines[i].Split(' ');
				if (arr[0] == "Square")
				{
					dataFromFile.Add(new Square(new Point(Convert.ToInt32(arr[1]), Convert.ToInt32(arr[2])), new Point(Convert.ToInt32(arr[3]), Convert.ToInt32(arr[4]))));
				}
				else
				{
					dataFromFile.Add(new Circle(new Point(Convert.ToInt32(arr[1]), Convert.ToInt32(arr[2])), Convert.ToDouble(arr[3])));
				}
			}
			var sortedBySquare =
				from elem in dataFromFile
				orderby elem.CalculateSquare()
				select elem;
			StreamWriter writer = new StreamWriter("../../File1.txt");
			foreach (var elem in sortedBySquare)
			{
				writer.WriteLine(elem);
			}
			writer.Close();
			Console.ReadKey();
		}
	}
}