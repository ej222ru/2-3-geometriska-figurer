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
			get { throw new NotImplementedException(); }
		}

		public override double TotalSurfaceArea
		{
			get { throw new NotImplementedException(); }
		}

		public override double Volume
		{
			get { throw new NotImplementedException(); }
		}

		public Sphere(double hradius, double vradius, double height)
			: base(ShapeType.Sphere, new Ellipse(hradius, vradius), height)
		{ 
		}
	}
}
