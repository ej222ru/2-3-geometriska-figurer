using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
	class Sphere : Shape3D
	{
		public override double MantelArea
		{
			get { return _baseShape.Area * 4; }
		}

		public override double TotalSurfaceArea
		{
			get { return MantelArea ; }
		}

		public override double Volume
		{
			get { return _baseShape.Area * (4/3) * Height; }
		}

		public Sphere( double radius)
			: base(ShapeType.Sphere, new Ellipse(radius, radius), radius)
		{ 
		}
	}
}
