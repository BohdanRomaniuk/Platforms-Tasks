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
using System.Xml;

namespace WPF_Hexagones
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<Polygon> Hexagones { get; private set; }
		private Polygon CurrentHexagone { get; set; }
		private uint Count { get; set; }
		private Color currentColor;
		public Color CurrentColor
		{
			get
			{
				return currentColor;
			}
			set
			{
				currentColor = value;
				OnPropertyChanged("CurrentColor");
			}
		}
		public ICommand DrawClick_Command { get; private set; }
		public ICommand ApplyColor_Command { get; set; }

		public ICommand ClearWindow_Command { get; private set; }
		public ICommand CloseWindow_Command { get; private set; }
		public ICommand OpenFile_Command { get; private set; }
		public ICommand SaveFile_Command { get; private set; }

		public MainViewModel()
		{
			Hexagones = new ObservableCollection<Polygon>();
			Count = 0;
			CurrentColor = Colors.Red;
			CurrentHexagone = new Polygon();
			ClearWindow_Command = new RelayCommand(ClearWindow);
			OpenFile_Command = new RelayCommand(OpenFile);
			SaveFile_Command = new RelayCommand(SaveFile);
			CloseWindow_Command = new RelayCommand(CloseWindow);
			DrawClick_Command = new RelayCommand(DrawClick);
			ApplyColor_Command = new RelayCommand(ApplyColor);
		}
		
		private void DrawClick(object obj)
		{
			Point mousePoint = Mouse.GetPosition((IInputElement)obj);
			CurrentHexagone.Stroke = Brushes.Black;
			CurrentHexagone.Points.Add(mousePoint);
			if(++Count==6)
			{
				ColorsWindow colorWin = new ColorsWindow(this);
				if(colorWin.ShowDialog()==true)
				{
					CurrentHexagone.Fill = new SolidColorBrush(CurrentColor);
				}
				CurrentHexagone.Name = String.Format("Hexagone_{0}", Hexagones.Count + 1);
				Hexagones.Add(CurrentHexagone);
				CurrentHexagone = new Polygon();
				OnPropertyChanged("Hexagones");
				Count = 0;
			}
		}

		private void ApplyColor(object obj)
		{
			ColorsWindow colorsWindow = (ColorsWindow)obj;
			colorsWindow.DialogResult = true;
			colorsWindow.Close();
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
				List<Hexagone> hexagones = new List<Hexagone>();
				XmlSerializer serializer = new XmlSerializer(typeof(List<Hexagone>));
				using (XmlReader reader = XmlReader.Create(fileName))
				{
					hexagones = (List<Hexagone>)serializer.Deserialize(reader);
				}
				Hexagones.Clear();
				for(int i=0; i<hexagones.Count; ++i)
				{
					Hexagones.Add(new Polygon() { Name = String.Format("Hexagone_{0}", i + 1), Points = hexagones[i].Points, Fill = new SolidColorBrush(hexagones[i].HexagoneColor) });
				}
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
				List<Hexagone> hexagones = new List<Hexagone>();
				foreach(var elem in Hexagones)
				{
					hexagones.Add(new Hexagone(elem));
				}
				using (Stream outputFile = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(List<Hexagone>));
					serializer.Serialize(outputFile, hexagones);
				}
			}
		}

		private void CloseWindow(object obj)
		{
			(obj as MainWindow).Close();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
