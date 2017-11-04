using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Input;
using Microsoft.Win32;

namespace WPF_Hexagones
{
	class MainViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<Polygon> Hexagones { get; private set; }
		private Polygon CurrentHexagone { get; set; }
		private uint Count { get; set; }
		private Color CurrentColor { get; set; }
		public ICommand DrawClick_Command { get; private set; }

		public ICommand ClearWindow_Command { get; private set; }
		public ICommand CloseWindow_Command { get; private set; }
		public ICommand OpenFile_Command { get; private set; }
		public ICommand SaveFile_Command { get; private set; }

		public MainViewModel()
		{
			Hexagones = new ObservableCollection<Polygon>();
			Hexagones.Add(new Polygon() { Stroke = Brushes.Black, Fill = new SolidColorBrush(Colors.Red), Name = String.Format("Hexagone_{0}", Hexagones.Count + 1), Points = new System.Windows.Media.PointCollection { new System.Windows.Point(10, 10), new System.Windows.Point(78, 90), new System.Windows.Point(140, 150) } });
			Hexagones.Add(new Polygon() { Name = String.Format("Hexagone_{0}", Hexagones.Count + 1) });
			OnPropertyChanged("Hexagones");
			Count = 0;
			CurrentHexagone = new Polygon();
			ClearWindow_Command = new RelayCommand(ClearWindow);
			OpenFile_Command = new RelayCommand(OpenFile);
			SaveFile_Command = new RelayCommand(SaveFile);
			CloseWindow_Command = new RelayCommand(CloseWindow);
			DrawClick_Command = new RelayCommand(DrawClick);
		}
		
		private void DrawClick(object obj)
		{
			Point mousePoint = Mouse.GetPosition((IInputElement)obj);
			CurrentHexagone.Stroke = Brushes.Black;
			CurrentHexagone.Points.Add(mousePoint);
			if(++Count==6)
			{
				ColorsWindow cw = new ColorsWindow();
				if(cw.ShowDialog()==true)
				{
					
				}
				CurrentColor = Colors.Red;
				CurrentHexagone.Fill = new SolidColorBrush(CurrentColor);
				Hexagones.Add(CurrentHexagone);
				CurrentHexagone = new Polygon();
				OnPropertyChanged("Hexagones");
				Count = 0;
			}
		}

		private void ClearWindow(object obj)
		{
			Hexagones.Clear();
			OnPropertyChanged("Hexagones");
		}

		private void OpenFile(object obj)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.DefaultExt = ".xml";
			openFileDialog.Filter = "XML documents (.xml)|*.xml";
			if (openFileDialog.ShowDialog() == true)
			{
				string fileName = openFileDialog.FileName;
			}
		}

		private void SaveFile(object obj)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = ".xml";
			saveFileDialog.FileName = "New_shapes.xml";
			saveFileDialog.Filter = "XML documents (.xml)|*.xml";
			if (saveFileDialog.ShowDialog() == true)
			{
				string fileName = saveFileDialog.FileName;

				/*
				 * using (Stream outputFile = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(List<Polygon>));
					serializer.Serialize(outputFile, hexagones);
				}
				*/
			}
		}

		private void CloseWindow(object obj)
		{
			var mainWindow = (Application.Current.MainWindow as MainWindow);
			if (mainWindow != null)
			{
				mainWindow.Close();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
