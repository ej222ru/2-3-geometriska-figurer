using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
	public enum ShapeType
	{
		Rectangle,
		Circle,
		Ellipse,
		Cuboid,
		Cylinder,
		Sphere
	}
	public abstract class Shape
	{
		private bool _isShape3d;

		// Properties
		public bool IsShape3d{
			get 
			{ 
				switch(ShapeType)
				{
					case ShapeType.Cuboid:
					case ShapeType.Ellipse:
					case ShapeType.Sphere:
					{
						return true;
					}
					default: return false;
				};
			}
		}
		public ShapeType ShapeType { get; private set; }

		// methods
		protected Shape(ShapeType shapeType)
		{
			ShapeType = shapeType;
		}
		public abstract string ToString(string format);
	}
}
