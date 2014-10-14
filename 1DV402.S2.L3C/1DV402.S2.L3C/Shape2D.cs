using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
	abstract class Shape2D : Shape, IComparable
	{
		private double _length;
		private double _width;

		// Properties
		public abstract double Area { get; }
		public double Length
		{
			get { return _length; }
			set
			{
				if (value < 0)
					throw new ArgumentException("Angivet värde på längd är mindre än 0");
				else
					_length = value; 
				}
		}
		public abstract double Perimeter { get; } 
		public double Width
		{ 
			get { return _width; }
			set
			{
				if (value < 0)
					throw new ArgumentException("Angivet värde på längd är mindre än 0");
				else
					_width = value;
			}
		}
 
		// methods
		int CompareTo(object obj)
		{
			if (obj == null) return 1;
			if (this == obj) return 0;

			// If parameter cannot be cast to Shape2D throw exception.
			Shape2D other = obj as Shape2D;
			if ((object)other == null)
			{
				throw new ArgumentException("Shape2D:CompareTo called with an object parameter that is not a Shape2D object");
			}
			if (other.Area > Area)
				return -1;
			else if (other.Area < Area)
				return 1;
			else
				return 0;
		}

		protected Shape2D(ShapeType shapeType, double length, double width)
			: base(shapeType)
		{
			Length = length;
			Width = width;
		}

		public override string ToString()
		{
			return ToString("G");
		}
		public override string ToString(string format)
		{
			if ((format == "G") || (format == "") || (format == null))
			{	// can I use string.join()  ???
				return string.Format("{0,-7}:{1,10:0.1}\n{2,-7}:{3,10}\n{4,-7}:{5,10}\n{6,-7}:{7,10}\n",
										Strings.length, Length,
										Strings.width, Width,
										Strings.perimeter, Perimeter,
										Strings.area, Area);
			}
			else if (format.Equals("R"))
			{   // can I use string.join()  ???
				return string.Format("{0,-10}{1,10:0.1}{2,10:0.1}{3,10:0.1}{4,10:0.1}", base.ShapeType.ToString(), Length, Width, Perimeter, Area);
			}
			else
			{
				throw new FormatException("Felaktig formatparameter till ToString, varken G eller R");
			}
		}

	}
}
