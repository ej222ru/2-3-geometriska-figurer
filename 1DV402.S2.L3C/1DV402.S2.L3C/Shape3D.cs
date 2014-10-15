using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
	abstract class Shape3D : Shape, IComparable
	{

		protected Shape2D _baseShape;
		private double _height;

		public double Height { 
			get {return _height; }
			set {
				if (value <= 0)
					throw new ArgumentException("Angivet värde på figurens höjd är 0 eller mindre");
				else
					_height = value;
			}
		}

		public abstract double MantelArea { get; }
		public abstract double TotalSurfaceArea { get; }
		public abstract double Volume { get; }  

		// methods
		public int CompareTo(object obj)
		{
			if (obj == null) return 1;
			if (this == obj) return 0;

			// If parameter cannot be cast to Shape3D throw exception.
			Shape3D other = obj as Shape3D;
			if ((object)other == null)
			{
				throw new ArgumentException("Shape3D:CompareTo called with an object parameter that is not a Shape3D object");
			}
			if (other.Volume > Volume)
				return -1;
			else if (other.Volume < Volume)
				return 1;
			else
				return 0;
		}

		protected Shape3D(ShapeType shapeType, Shape2D baseShape, double height)
			: base(shapeType)
		{
			_baseShape = baseShape;
			Height = height;
		}

		public override string ToString()
		{
			return ToString("G");
		}
		public override string ToString(string format)
		{
			if ((format == "G") || (format == "") || (format == null))
			{	// can I use string.join()  ???
				return string.Format("{0,-7}:{1,10:0.0}\n{2,-7}:{3,10:0.0}\n{4,-7}:{5,10:0.0}\n{6,-7}:{7,10:0.0}\n{8,-7}:{9,10:0.0}\n{10,-7}:{11,10:0.0}\n",
										Strings.length, _baseShape.Length,
										Strings.width, _baseShape.Width,
										Strings.height, Height,
										Strings.mantelArea, MantelArea,
										Strings.totalSurfaceArea, TotalSurfaceArea,
										Strings.volume, Volume);

			}
			else if (format.Equals("R"))
			{   // can I use string.join()  ???
				return string.Format("{0,-10}{1,10:0.0}{2,10:0.0}{3,10:0.0}{4,15:0.0}{5,15:0.0}{6,15:0.0}", base.ShapeType.ToString(), _baseShape.Length, _baseShape.Width, Height, MantelArea, TotalSurfaceArea, Volume);
			}
			else
			{
				throw new FormatException("Felaktig formatparameter till ToString, varken G eller R");
			}
	


			if ((format == "G") || (format == "") || (format == null))
				return string.Format("{0,-7}:{1:0.1}\n{2,-7}:{3,10}\n{4,-7}:{5,10}\n{6,-7}:{7,10}\n",
										Strings.length, _baseShape.Length,
										Strings.width, _baseShape.Width,
										Strings.height, Height,
										Strings.mantelArea, MantelArea,
										Strings.totalSurfaceArea, TotalSurfaceArea,
										Strings.volume, Volume);
			else if (format.Equals("R"))
			{
				return string.Format("{0,-10}{1,10:0.1}{2,10:0.1}{3,10:0.1}{4,10:0.1}{5,10:0.1}{6,10:0.1}", base.ShapeType.ToString(),
										_baseShape.Length, _baseShape.Width, Height, MantelArea, TotalSurfaceArea, Volume);
			}
			else 
			{  
				throw new FormatException("Felaktig formatparameter till ToString, varken G eller R");
			}
		}


	}
}
