using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPF_Hexagones
{
	[Serializable]
	public class Hexagone
	{
		public PointCollection Points { get;set;}
		public Color HexagoneColor { get; set; }
		public Hexagone() { }
		public Hexagone(Polygon figure)
		{
			Points = figure.Points;
			HexagoneColor = (figure.Fill as SolidColorBrush).Color;
		}
    }
}
