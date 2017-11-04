using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Xml.Serialization;

namespace WPF_Hexagones
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
		private Polygon currentHexagone;
        private Color currentColor = Colors.RoyalBlue;
        private Polyline currentLine = new Polyline();
        private int sideCount = 0;
        private List<Polygon> hexagones = new List<Polygon>();
		*/

        public MainWindow()
        {
            InitializeComponent();
			DataContext = new MainViewModel();
        }

		/*
        private void NewFigure_Click(object sender, RoutedEventArgs e)
        {
            surface.Children.Clear();
        }

        private void OpenFigure_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".xml";
            openFileDialog.Filter = "XML documents (.xml)|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
            }
        }

        private void SaveFigure_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".xml";
            saveFileDialog.FileName = "New_shapes.xml";
            saveFileDialog.Filter = "XML documents (.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                string fileName = saveFileDialog.FileName;

                using (Stream outputFile = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Polygon>));
                    serializer.Serialize(outputFile, hexagones);
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (currentHexagone == null)
            {
                var surface = (Canvas)sender;
                var point = e.GetPosition(surface);

                // Нова лінія для шестикутника (чорного кольору)
                currentHexagone = new Polygon();
                currentHexagone.Stroke = Brushes.Black;
                currentHexagone.Points.Add(point);
                
                surface.Children.Add(currentHexagone);

                // initialize current polyline currentLine
                currentLine.Stroke = Brushes.Red;
                currentLine.Points.Add(point);
                currentLine.Points.Add(point);
                surface.Children.Add(currentLine);
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentHexagone != null)
            {
                // Малює нову лінію червоного кольору
                var surface = (Canvas)sender;
                currentLine.Points[1] = e.GetPosition(surface);
                currentLine.Stroke = Brushes.Red;
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (currentHexagone != null)
            {
                var surface = (Canvas)sender;
                currentLine.Points[1] = e.GetPosition(surface);

                currentHexagone.Points.Add(currentLine.Points[1]);
                currentLine.Points[0] = currentLine.Points[1];

                if (++sideCount == 6)
                {
                    sideCount = 0;
                    ColorsWindow colWin = new ColorsWindow();
                    colWin.Show();
                    currentHexagone.Fill = new SolidColorBrush(currentColor);
                    hexagones.Add(currentHexagone);
                    currentHexagone = null;
                    currentLine.Points.Clear();
                    surface.Children.Remove(currentLine);
                }
            }
        }
		*/
    }
}
