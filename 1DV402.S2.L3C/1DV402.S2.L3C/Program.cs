using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _1DV402.S2.L3C
{
	class Program
	{
		static void Main(string[] args)
		{
			int i = 0;
			VievMenu();
		}
		Shape CreateShape(ShapeType shapeType)
		{
			switch (shapeType)
			{
				case ShapeType.Circle :
					{
					Console.Write( shapeType.AsText()  );
						break;  
					}
			}

			Shape shape = new Cuboid(1,2,3);
			return shape;
		}
/*
		Shape2D[] Randomize2DShapes()
		{

		}
		Shape3D[] Randomize3DShapes()
		{

		}
		double[] ReadDimensions(ShapeType shapeType)
		{
		} 
		double[] ReadDoublesGreaterThanZero(string prompt, int numberOfValues=1)
		{
		}
*/
		private static void VievMenu()
		{
			Console.BackgroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(Strings.divider);
			Console.WriteLine(" ".CenterAlignString(Strings.divider));
			Console.WriteLine(Strings.geometricObjects.CenterAlignString(Strings.divider));
			Console.WriteLine(" ".CenterAlignString(Strings.divider));
			Console.WriteLine(Strings.divider);
			Console.ResetColor();
			Console.WriteLine("");
			string menuChoice = "";
			for (int i=0;i<9;i++)
			{
				switch (i)
				{
					case 0: menuChoice = Strings.finish;break;
					case 1: menuChoice = Strings.rectangle;break;
					case 2: menuChoice = Strings.circle;break;
					case 3: menuChoice = Strings.ellipse;break;
					case 4: menuChoice = Strings.cuboid;break;
					case 5: menuChoice = Strings.cylinder;break;
					case 6: menuChoice = Strings.sphere;break;
					case 7: menuChoice = Strings.random2D;break;
					case 8: menuChoice = Strings.random3D;break;
				}
				Console.WriteLine(string.Format("{0}. {1}.", i, menuChoice));
			}
			Console.WriteLine("");
			Console.WriteLine(Strings.divider);
			Console.WriteLine("");
			Console.Write(Strings.menuChoice);
		}

		void ViewMenuErrorMessage()
		{

		}
		void ViewShapeDetail(Shape shape)
		{

		}
		void ViewShapes(Shape[] shapes)
		{

		}
	}
}
