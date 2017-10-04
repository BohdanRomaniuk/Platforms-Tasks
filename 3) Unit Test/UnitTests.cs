using Microsoft.VisualStudio.TestTools.UnitTesting;
using LNU.AMI33.Rommaniuk.Variant1;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System;

namespace LNU.AMI33.Rommaniuk
{
	[TestClass]
	public class UnitTests
	{
		[TestMethod]
		public void TestAllPropertyAndToString()
		{
			Point testPoint = new Point();
			testPoint.X = 56;
			testPoint.Y = -99;
			Assert.AreEqual(testPoint.ToString(), "(56,-99)");

			Circle testCircle = new Circle();
			testCircle.Center = new Point(5, 6);
			testCircle.Radius = 23;
			Assert.AreEqual(testCircle.ToString(), "Circle: center=(5,6), radius=23");

			Square testSquare = new Square();
			testSquare.LeftTop = new Point(0, 17);
			testSquare.RightBottom = new Point(14, 5);
			Assert.AreEqual(testSquare.ToString(), "Square: left top=(0,17), right bottom=(14,5)");
		}

		[TestMethod]
		public void TestCirclePerimetrAndSquare()
		{
			//Radius of circle
			double radius = 23;
			Circle testCircle = new Circle(new Point(-27, -98), radius);

			Assert.AreEqual(testCircle.CalculatePerimeter(), 2 * Math.PI * radius);
			Assert.AreEqual(testCircle.CalculateSquare(), Math.PI * Math.Pow(radius, 2));
		}

		[TestMethod]
		public void TestSquarePerimetrAndSquare()
		{
			//Left Top point
			int x1 = -20;
			int y1 = 45;

			//Right Bottom point
			int x2 = 43;
			int y2 = 12;
			Square testSquare = new Square(new Point(x1, y1), new Point(x2, y2));

			Assert.AreEqual(testSquare.CalculatePerimeter(), 2 * ((x2 - x1) + (y1 - y2)));
			Assert.AreEqual(testSquare.CalculateSquare(), (x2 - x1) * (y1 - y2));
		}

		[TestMethod]
		public void TestCircleIsInThirdQuarter()
		{
			Circle circleInThirdQuarter = new Circle(new Point(-14, -19), 10);
			bool isInThirdQuarter1 = circleInThirdQuarter.IsInThirdQuarter();

			Circle circleNotInThirdQuarter = new Circle(new Point(-4, -5), 10);
			bool isInThirdQuarter2 = circleNotInThirdQuarter.IsInThirdQuarter();

			Assert.AreEqual(isInThirdQuarter1, true);
			Assert.AreEqual(isInThirdQuarter2, false);
		}

		[TestMethod]
		public void TestSquareIsInThirdQuarter()
		{
			Square squareInThirdQuarter = new Square(new Point(-20, -10), new Point(-7, -15));
			bool isInThirdQuarter1 = squareInThirdQuarter.IsInThirdQuarter();

			Square squareNotInThirdQuarter = new Square(new Point(-5, -4), new Point(1, -7));
			bool isInThirdQuarter2 = squareNotInThirdQuarter.IsInThirdQuarter();

			Assert.AreEqual(isInThirdQuarter1, true);
			Assert.AreEqual(isInThirdQuarter2, false);
        }

		[TestMethod]
		public void TestWritingToFile()
		{
			List<Figure> allFigures = new List<Figure>();
			allFigures.Add(new Circle(new Point(5, 6), 1));
			allFigures.Add(new Square(new Point(11, 3), new Point(17, 6)));
			allFigures.Add(new Circle(new Point(7, 8), 9));
			MainProgram.WriteFiguresToFile(allFigures, "../../res.xml");
			Assert.AreNotEqual(new FileInfo("../../res.xml").Length, 0);

			List<Circle> circles = new List<Circle>();
			circles.Add(new Circle(new Point(5, 6), 1));
			circles.Add(new Circle(new Point(7, 8), 9));
			(new Circle()).WriteToFile(circles, "../../res1.xml");
			Assert.AreNotEqual(new FileInfo("../../res1.xml").Length, 0);

			List<Square> squares = new List<Square>();
			squares.Add(new Square(new Point(7, 8), new Point(10, 4)));
			squares.Add(new Square(new Point(11, 3), new Point(17, 6)));
			squares.Add(new Square(new Point(23, 7), new Point(34, 8)));
			(new Square()).WriteToFile(squares, "../../res2.xml");
			Assert.AreNotEqual(new FileInfo("../../res2.xml").Length, 0);
		}

		[TestMethod]
		[ExpectedException(typeof(FileNotFoundException))]

		public void TestReadingFromNonExistFile()
		{
			List <Figure> inputCollection = new List<Figure>();
			inputCollection = MainProgram.ReadFiguresFromFile("../../input.txt");
        }

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestNotCorrectImplementOfSquare()
		{
			Square testSquare = new Square(new Point(3, 4), new Point(10, 0));
			//Not right bottom point
			testSquare.RightBottom = new Point(0, 45);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestNotCorrectImplementOfCircle()
		{
			Circle testCircle = new Circle(new Point(7, 12), 30);
			//Less equal value of radius
			testCircle.Radius = -10;
		}
	}
}
