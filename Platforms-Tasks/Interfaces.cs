using System.Collections.Generic;

namespace LNU.AMI33.Rommaniuk.Variant1
{
	interface IShape
	{
		double CalculatePerimeter();
		double CalculateSquare();
	}
	interface IFileManager<T>
	{
		List<T> ReadFromFile(string fileName);
		void WriteToFile(List<T> outputFigures, string fileName);
	}
}
