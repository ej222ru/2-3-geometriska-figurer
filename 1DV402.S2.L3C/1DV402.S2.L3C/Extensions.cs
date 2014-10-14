using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
	static class Extensions
	{

		public static string AsText(this ShapeType shapeType)
		{
			switch (shapeType)
			{
				case ShapeType.Circle : return "Cirkel";
				case ShapeType.Cuboid : return "Rätblock";
				case ShapeType.Cylinder : return "Cylinder";
				case ShapeType.Ellipse : return "Ellips";
				case ShapeType.Rectangle : return "Rektangel";
				case ShapeType.Sphere : return "Sfär";
			}
			return "AsText() namn för shapeType saknas";
		}

		public static string CenterAlignString(this string s, string other)
		{
			int spaces = ((other.Length - s.Length) / 2);
			int odd = ((other.Length - s.Length) % 2);

			string padLeft = "=".PadRight(spaces);
			string padRight = "=".PadLeft(spaces + odd);
			return string.Format("{0}{1}{2}", padLeft, s, padRight);
		}
	}
}
