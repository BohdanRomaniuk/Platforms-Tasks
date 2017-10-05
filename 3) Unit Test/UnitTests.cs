using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LNU.AMI33.Rommaniuk.Variant1;

namespace LNU.AMI33.Rommaniuk
{
	[TestClass]
	public class PointTesting
	{
		[TestMethod]
		public void Test_PointPropertiesAndToString()
		{
			Point testPoint = new Point();
			testPoint.X = 56;
			testPoint.Y = -99;
			Assert.AreEqual(testPoint.ToString(), "(56,-99)");
		}
	}

	[TestClass]
	public class SquareTesting
	{
		[TestMethod]
		public void Test_SquarePropertiesAndToString()
		{
			Square testSquare = new Square();
			testSquare.LeftTop = new Point(0, 17);
			testSquare.RightBottom = new Point(14, 5);
			Assert.AreEqual(testSquare.ToString(), "Square: left top=(0,17), right bottom=(14,5)");
		}

		[TestMethod]
		public void Test_SquarePerimetr()
		{
			//Left Top point
			int x1 = -20;
			int y1 = 45;

			//Right Bottom point
			int x2 = 43;
			int y2 = 12;
			Square testSquare = new Square(new Point(x1, y1), new Point(x2, y2));

			Assert.AreEqual(testSquare.CalculatePerimeter(), 2 * ((x2 - x1) + (y1 - y2)));
		}

		[TestMethod]
		public void Test_SquareArea()
		{
			//Left Top point
			int x1 = -20;
			int y1 = 45;

			//Right Bottom point
			int x2 = 43;
			int y2 = 12;
			Square testSquare = new Square(new Point(x1, y1), new Point(x2, y2));

			Assert.AreEqual(testSquare.CalculateSquare(), (x2 - x1) * (y1 - y2));
		}

		[TestMethod]
		public void Test_SquareIsInThirdQuarter()
		{
			Square squareInThirdQuarter = new Square(new Point(-20, -10), new Point(-7, -15));
			bool isInThirdQuarter1 = squareInThirdQuarter.IsInThirdQuarter();

			Square squareNotInThirdQuarter = new Square(new Point(-5, -4), new Point(1, -7));
			bool isInThirdQuarter2 = squareNotInThirdQuarter.IsInThirdQuarter();

			Assert.AreEqual(isInThirdQuarter1, true);
			Assert.AreEqual(isInThirdQuarter2, false);
		}

		[TestMethod]
		[ExpectedException(typeof(FileNotFoundException))]

		public void Test_SquareReadingFromNonExistFile()
		{
			List<Square> inputCollection = new List<Square>();
			inputCollection = (new Square()).ReadFromFile("../../input.xml");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Test_SquareNotCorrectImplement()
		{
			Square testSquare = new Square(new Point(3, 4), new Point(10, 0));
			//Not right bottom point
			testSquare.RightBottom = new Point(0, 45);
		}
	}

	[TestClass]
	public class CircleTesting
	{
		[TestMethod]
		public void Test_CircleAllPropertiesAndToString()
		{
			Circle testCircle = new Circle();
			testCircle.Center = new Point(5, 6);
			testCircle.Radius = 23;
			Assert.AreEqual(testCircle.ToString(), "Circle: center=(5,6), radius=23");
		}

		[TestMethod]
		public void Test_CirclePerimetr()
		{
			//Radius of circle
			double radius = 23;
			Circle testCircle = new Circle(new Point(-27, -98), radius);

			Assert.AreEqual(testCircle.CalculatePerimeter(), 2 * Math.PI * radius);
		}

		[TestMethod]
		public void Test_CircleArea()
		{
			//Radius of circle
			double radius = 23;
			Circle testCircle = new Circle(new Point(-27, -98), radius);

			Assert.AreEqual(testCircle.CalculateSquare(), Math.PI * Math.Pow(radius, 2));
		}
		

		[TestMethod]
		public void Test_CircleIsInThirdQuarter()
		{
			Circle circleInThirdQuarter = new Circle(new Point(-14, -19), 10);
			bool isInThirdQuarter1 = circleInThirdQuarter.IsInThirdQuarter();

			Circle circleNotInThirdQuarter = new Circle(new Point(-4, -5), 10);
			bool isInThirdQuarter2 = circleNotInThirdQuarter.IsInThirdQuarter();

			Assert.AreEqual(isInThirdQuarter1, true);
			Assert.AreEqual(isInThirdQuarter2, false);
		}

		[TestMethod]
		[ExpectedException(typeof(FileNotFoundException))]

		public void Test_CircleReadingFromNonExistFile()
		{
			List <Circle> inputCollection = new List<Circle>();
			inputCollection = (new Circle()).ReadFromFile("../../input.xml");
        }

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Test_CircleNotCorrectImplement()
		{
			Circle testCircle = new Circle(new Point(7, 12), 30);
			//Less equal value of radius
			testCircle.Radius = -10;
		}
	}
}
