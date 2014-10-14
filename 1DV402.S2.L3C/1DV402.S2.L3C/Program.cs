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

			VievMenu();
			int choice = int.Parse(Console.ReadLine());

			if ((choice < 0) || (choice > 8))
			{
			};

			if ((choice > 0) && (choice < 7))
			{

				ShapeType shapeType = ShapeType.Circle;
				switch (choice)
				{
					case 1:
						{
							shapeType = ShapeType.Rectangle;
							break;
						}
					case 2:
						{
							shapeType = ShapeType.Circle;
							break;
						}
					case 3:
						{
							shapeType = ShapeType.Ellipse;
							break;
						}
					case 4:
						{
							shapeType = ShapeType.Cuboid;
							break;
						}
					case 5:
						{
							shapeType = ShapeType.Cylinder;
							break;
						}
					case 6:
						{
							shapeType = ShapeType.Sphere;
							break;
						}
				}

				Shape shape = CreateShape(shapeType);
			}
			else if (choice == 7)
			{
				Randomize2DShapes();
			}
			else if (choice == 8)
			{
//				Randomize3DShapes();
			}

	
		}
		private static Shape CreateShape(ShapeType shapeType)
		{
			Shape shape = null;
			switch (shapeType)
			{  
				case ShapeType.Circle:
					{

						break;
					}
				case ShapeType.Cuboid :
					{
						Console.BackgroundColor = ConsoleColor.DarkRed;
						Console.WriteLine(Strings.divider);
						Console.WriteLine(Strings.cuboid.CenterAlignString(Strings.divider));
						Console.WriteLine(Strings.divider);
						Console.ResetColor();
						Console.WriteLine("");
						double[] sides = ReadDimensions(shapeType);
						shape = new Cuboid(sides[0], sides[1], sides[2]);
						break;
					}
				case ShapeType.Cylinder:
					{

						break;
					}
				case ShapeType.Ellipse:
					{

						break;
					}
				case ShapeType.Rectangle:
					{

						break;
					}
				case ShapeType.Sphere:
					{

						break;
					}
			}

			return shape;
		}

		private static Shape2D[] Randomize2DShapes()
		{
			int noOfObjects = 5;
			Shape2D[] shapes = new Shape2D[noOfObjects];
			double length = 7.2;
			double width = 14.3;

			for (int i = 0; i < noOfObjects; i++)
			{
				int randomShapeType = 1;
				switch (randomShapeType)
				{
					case 0 : shapes[i] = new Ellipse(length, width); break;
					case 1 : shapes[i] = new Ellipse(length); break;
					case 2 : shapes[i] = new Rectangle(length, width); break;
				}
			}
			return shapes;
		}
		/*
				private static Shape3D[] Randomize3DShapes()
				{

				}
		 *		 */
		private static double[] ReadDimensions(ShapeType shapeType)
		{
			string prompt = "";
			int args = 0;
			switch (shapeType)
			{
				case ShapeType.Circle:
					{
						prompt = Strings.circle;
						args = 1;
						break;
					}
				case ShapeType.Cuboid:
					{
						prompt = Strings.cuboidDoubles;
						args = 3;
						break;
					}
				case ShapeType.Cylinder:
					{
						prompt = Strings.cylinder;
						args = 3;
						break;
					}
				case ShapeType.Ellipse:
					{
						prompt = Strings.ellipse;
						args = 2;
						break;
					}
				case ShapeType.Rectangle:
					{
						prompt = Strings.rectangle;
						args = 2;
						break;
					}
				case ShapeType.Sphere:
					{
						prompt = Strings.sphere;
						args = 3;
						break;
					}

			}

			return ReadDoublesGreaterThanZero(prompt, args);
		} 

		private static double[] ReadDoublesGreaterThanZero(string prompt, int numberOfValues=1)
		{
			Console.Write(prompt);
			string input = Console.ReadLine();
			string[] args = input.Split(' ');
			double[] arguments = new double [args.Length];
			for (int i = 0; i < args.Length; i++)
			{
				arguments[i] = double.Parse(args[i]);
			}
			return arguments;
		}

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
