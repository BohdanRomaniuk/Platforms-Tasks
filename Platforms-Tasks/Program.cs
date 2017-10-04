using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace LNU.AMI33.Rommaniuk.Variant1
{
	public class MainProgram
	{
		public static List<Figure> ReadFiguresFromFile(string fileName)
		{
			XmlSerializer deserializer = new XmlSerializer(typeof(List<Figure>));
			List<Figure> deserializedFigures;
			using (XmlReader reader = XmlReader.Create(fileName))
			{
				deserializedFigures = (List<Figure>)deserializer.Deserialize(reader);
			}
			return deserializedFigures;
		}
		public static void WriteFiguresToFile(List<Figure> outputFigures, string fileName)
		{
			using (Stream outputFile = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Figure>));
				serializer.Serialize(outputFile, outputFigures);
			}
		}
		static void Main(string[] args)
		{
			//try
			//{
				List<Figure> dataFromFile = new List<Figure>();
				string inputFileName = "../../Input.xml";
				if (!File.Exists(inputFileName))
				{
					throw new FileNotFoundException(String.Format("File {0} not found!", inputFileName.Replace("../../", String.Empty)));
				}
				if (new FileInfo(inputFileName).Length == 0)
				{
					throw new FileLoadException(String.Format("File {0} is empty!", inputFileName.Replace("../../", String.Empty)));
				}
				dataFromFile = ReadFiguresFromFile("../../INSINDAS.XML");
				Console.WriteLine((dataFromFile.Count != 0) ? "Succesfully deserialized from file!" : "Nothing readed from file");
				dataFromFile.Sort((fig1, fig2) => fig1.CalculateSquare().CompareTo(fig2.CalculateSquare()));
				string sortedOutputFileName = "../../File1.xml";
				WriteFiguresToFile(dataFromFile as List<Figure>, sortedOutputFileName);
				Console.WriteLine((new FileInfo(sortedOutputFileName).Length == 0) ? "Error while writing to File1.xml" : "Sorted by square list writen to File1.xml");
				List<Figure> figuresInThirdQuarter =
					(from element in dataFromFile
					 where element.IsInThirdQuarter()
					 orderby element.CalculatePerimeter()
					 select element).ToList<Figure>();
				string thirdQuarterElemsOutputFileName = "../../File2.xml";
				WriteFiguresToFile(figuresInThirdQuarter as List<Figure>, thirdQuarterElemsOutputFileName);
				Console.WriteLine((new FileInfo(thirdQuarterElemsOutputFileName).Length == 0) ? "Error while writing to File2.xml" : "Sorted by perimitr in third quarter list writen to File2.xml");
			/*}
			catch (FileNotFoundException fileMissingException)
			{
				Console.WriteLine("File missing! {0}", fileMissingException.Message);
			}
			catch (FileLoadException fileIsEmptyException)
			{
				Console.WriteLine("Something go wrong with file! {0}", fileIsEmptyException.Message);
			}
			catch (Exception generalError)
			{
				Console.WriteLine("Some error occured! {0}", generalError.Message);
			}
			finally
			{
				Console.ReadKey();
			}*/
		}
	}
}

