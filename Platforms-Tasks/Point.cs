using System;

namespace LNU.AMI33.Rommaniuk.Variant1
{
	[Serializable]
	public class Point
	{
		private int x;
		private int y;
		public int X
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}
		public int Y
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}
		public Point()
		{
		}
		public Point(int _x, int _y)
		{
			X = _x;
			Y = _y;
		}
		public override string ToString()
		{
			return String.Format("({0},{1})", X, Y);
		}
	}
}
