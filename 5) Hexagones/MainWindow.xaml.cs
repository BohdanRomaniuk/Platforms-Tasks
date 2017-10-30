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

namespace _5__Hexagones
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Polygon currentPolygon;
        private Polyline currentSegment = new Polyline();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (currentPolygon == null)
            {
                var Surface = (Canvas)sender;
                var point = e.GetPosition(Surface);

                // create new polyline
                currentPolygon = new Polygon();
                currentPolygon.Stroke = Brushes.Black;
                currentPolygon.Points.Add(point);
                currentPolygon.Fill = new SolidColorBrush(Colors.Blue);
                Surface.Children.Add(currentPolygon);

                // initialize current polyline currentSegment
                currentSegment.Stroke = Brushes.Red;
                currentSegment.Points.Add(point);
                currentSegment.Points.Add(point);
                Surface.Children.Add(currentSegment);
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentPolygon != null)
            {
                // update current polyline currentSegment
                var Surface = (Canvas)sender;
                currentSegment.Points[1] = e.GetPosition(Surface);
                currentSegment.Stroke = Brushes.Blue;
            }
        }

        private void Canvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            currentPolygon = null;
            currentSegment.Points.Clear();
            Surface.Children.Remove(currentSegment);
        }
        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (currentPolygon != null)
            {
                var Surface = (Canvas)sender;
                currentSegment.Points[1] = e.GetPosition(Surface);

                currentPolygon.Points.Add(currentSegment.Points[1]);
                currentSegment.Points[0] = currentSegment.Points[1];
            }
        }
        private void NewFigure_Click(object sender, RoutedEventArgs e)
        {
            Surface.Children.Clear();
        }

        private void OpenFigure_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SaveFigure_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
