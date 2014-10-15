using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _1DV402.S2.L3C
{
	class Program
	{
		private static Random generator;

		static void Main(string[] args)
		{
			Console.Title = Strings.Title;

			bool continueCalc = false;
			do
			{
				generator = new Random();
				Shape[] shapes = null;
				VievMenu();
				try
				{
					int choice = int.Parse(Console.ReadLine());

					if ((choice < 0) || (choice > 8))
					{
						throw new Exception(Strings.ErrorMessage1);
					}
					else if ((choice > 0) && (choice < 7))
					{

						ShapeType shapeType = ShapeType.Circle;
						switch (choice)
						{
							case 1: { shapeType = ShapeType.Rectangle; break; }
							case 2: { shapeType = ShapeType.Circle; break; }
							case 3: { shapeType = ShapeType.Ellipse; break; }
							case 4: { shapeType = ShapeType.Cuboid; break; }
							case 5: { shapeType = ShapeType.Cylinder; break; }
							case 6: { shapeType = ShapeType.Sphere; break; }
							default: break;
						}
						Shape shape = CreateShape(shapeType);
						ViewShapeDetail(shape);
					}
					else if (choice == 7)
					{
						shapes = Randomize2DShapes();
					}
					else if (choice == 8)
					{
						shapes = Randomize3DShapes();
					}
					if (shapes != null)
						ViewShapes(shapes);
				}
				catch (Exception ex)
				{
					ViewMenuErrorMessage(ex.Message);
				}


				Console.WriteLine();

				Console.BackgroundColor = ConsoleColor.DarkBlue;
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write(Strings.continuePromt);
				Console.CursorVisible = false;
				continueCalc = Console.ReadKey(true).Key != ConsoleKey.Escape;
				Console.CursorVisible = true;
				Console.ResetColor();
				Console.WriteLine();
			} while (continueCalc);

		}
		private static Shape CreateShape(ShapeType shapeType)
		{
			Shape shape = null;
			switch (shapeType)
			{
				case ShapeType.Circle:
					{
						VievHeader(Strings.circle);
						double[] sides = ReadDimensions(shapeType);
						shape = new Ellipse(sides[0]);
						break;
					}
				case ShapeType.Cuboid:
					{
						VievHeader(Strings.cuboid);
						double[] sides = ReadDimensions(shapeType);
						shape = new Cuboid(sides[0], sides[1], sides[2]);
						break;
					}
				case ShapeType.Cylinder:
					{
						VievHeader(Strings.cylinder);
						double[] sides = ReadDimensions(shapeType);
						shape = new Cylinder(sides[0], sides[1], sides[2]);
						break;
					}
				case ShapeType.Ellipse:
					{
						VievHeader(Strings.ellipse);
						double[] sides = ReadDimensions(shapeType);
						shape = new Ellipse(sides[0], sides[1]);
						break;
					}
				case ShapeType.Rectangle:
					{
						VievHeader(Strings.rectangle);
						double[] sides = ReadDimensions(shapeType);
						shape = new Rectangle(sides[0], sides[1]);
						break;
					}
				case ShapeType.Sphere:
					{
						VievHeader(Strings.sphere);
						double[] sides = ReadDimensions(shapeType);
						shape = new Sphere(sides[0]);
						break;
					}
				default: break;

			}

			return shape;
		}

		private static Shape2D[] Randomize2DShapes()
		{
			int noOfObjects = generator.Next(5, 21);
			Shape2D[] shapes = new Shape2D[noOfObjects];
			int randomShapeType;

			for (int i = 0; i < noOfObjects; i++)
			{
				randomShapeType = generator.Next(0, 3);
				switch (randomShapeType)
				{
					case 0:
						{
							shapes[i] = new Ellipse(GetRandomNumber(5.0, 100.0), GetRandomNumber(5.0, 100.0));
							break;
						}
					case 1:
						{
							shapes[i] = new Ellipse(GetRandomNumber(5.0, 100.0));
							break;
						}
					case 2:
						{
							shapes[i] = new Rectangle(GetRandomNumber(5.0, 100.0), GetRandomNumber(5.0, 100.0));
							break;
						}
					default: break;
				}
			}
			return shapes;
		}
		private static Shape3D[] Randomize3DShapes()
		{
			int noOfObjects = generator.Next(5, 21);
			Shape3D[] shapes = new Shape3D[noOfObjects];
			int randomShapeType;

			for (int i = 0; i < noOfObjects; i++)
			{
				randomShapeType = generator.Next(3, 6);
				switch (randomShapeType)
				{
					case 3:
						{
							shapes[i] = new Cuboid(GetRandomNumber(5.0, 100.0), GetRandomNumber(5.0, 100.0), GetRandomNumber(5.0, 100.0));
							break;
						}
					case 4:
						{
							shapes[i] = new Cylinder(GetRandomNumber(5.0, 100.0), GetRandomNumber(5.0, 100.0), GetRandomNumber(5.0, 100.0));
							break;
						}
					case 5:
						{
							shapes[i] = new Sphere(GetRandomNumber(5.0, 100.0));
							break;
						}
					default: break;
				}
			}
			return shapes;

		}

		private static double[] ReadDimensions(ShapeType shapeType)
		{
			string prompt = "";
			int args = 0;
			switch (shapeType)
			{
				case ShapeType.Circle:
					{
						prompt = Strings.circleInputText;
						args = 1;
						break;
					}
				case ShapeType.Cuboid:
					{
						prompt = Strings.cuboidInputText;
						args = 3;
						break;
					}
				case ShapeType.Cylinder:
					{
						prompt = Strings.cylinderInputText;
						args = 3;
						break;
					}
				case ShapeType.Ellipse:
					{
						prompt = Strings.ellipseInputText;
						args = 2;
						break;
					}
				case ShapeType.Rectangle:
					{
						prompt = Strings.rectangleInputText;
						args = 2;
						break;
					}
				case ShapeType.Sphere:
					{
						prompt = Strings.sphereInputText;
						args = 1;
						break;
					}
				default: break;
			}
			return ReadDoublesGreaterThanZero(prompt, args);
		}
		private static double[] ReadDoublesGreaterThanZero(string prompt, int numberOfValues = 1)
		{
			bool done = false;
			double[] arguments = null;
			do
			{
				try
				{
					Console.Write(prompt);
					string input = Console.ReadLine();
					string[] args = input.Split(' ');
					if (args.Length != numberOfValues)
						throw new ArgumentException("Fel antal parametrar angivna! Ange dom med mellanslag som separator");
					arguments = new double[args.Length];
					for (int i = 0; i < args.Length; i++)
					{
						arguments[i] = double.Parse(args[i]);
						if (arguments[i] <= 0)
							throw new Exception("Parametrar måste vara större än 0");
					}
					done = true;
				}
				catch (ArgumentException ex)
				{
					ViewMenuErrorMessage(ex.Message);
				}
				catch (FormatException)
				{
					ViewMenuErrorMessage("Du måste ge ett tal och om det är decimaler så ska det vara ett kommatecken, inte punkt");
				}
				catch (Exception ex)
				{
					ViewMenuErrorMessage(ex.Message);
				}
				catch
				{
					ViewMenuErrorMessage(Strings.ErrorMessage2);
				}
			} while (done == false);
			return arguments;
		}

		private static void VievHeader(string text)
		{
			Console.BackgroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(Strings.divider);
			Console.WriteLine(text.CenterAlignString(Strings.divider));
			Console.WriteLine(Strings.divider);
			Console.ResetColor();
			Console.WriteLine("");
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
			for (int i = 0; i < 9; i++)
			{
				switch (i)
				{
					case 0: menuChoice = Strings.finish; break;
					case 1: menuChoice = Strings.rectangle; break;
					case 2: menuChoice = Strings.circle; break;
					case 3: menuChoice = Strings.ellipse; break;
					case 4: menuChoice = Strings.cuboid; break;
					case 5: menuChoice = Strings.cylinder; break;
					case 6: menuChoice = Strings.sphere; break;
					case 7: menuChoice = Strings.random2D; break;
					case 8: menuChoice = Strings.random3D; break;
				}
				Console.WriteLine(string.Format("{0}. {1}.", i, menuChoice));
			}
			Console.WriteLine("");
			Console.WriteLine(Strings.divider);
			Console.WriteLine("");
			Console.Write(Strings.menuChoice);
		}
		private static void ViewMenuErrorMessage(string message)
		{
			Console.WriteLine("");
			Console.BackgroundColor = ConsoleColor.Red;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(message);
			Console.ResetColor();
			Console.WriteLine("");
		}
		private static void ViewShapeDetail(Shape shape)
		{
			VievHeader(Strings.details);
			Console.WriteLine(shape.ToString("G"));
		}
		private static void ViewShapes(Shape[] shapes)
		{
			if (shapes.Length > 0)
			{
				Console.BackgroundColor = ConsoleColor.DarkRed;
				string text = null;
				switch (shapes[0].ShapeType)
				{
					case ShapeType.Rectangle :
					case ShapeType.Circle :
					case ShapeType.Ellipse :
						{
							text = string.Format("{0,-10}{1,10}{2,10}{3,10}{4,10}", "Figur", "Längd", "Bredd", "Omkrets", "Area");
							break;
						}
					default:
						{
							text = string.Format("{0,-10}{1,10}{2,10}{3,10}{4,15}{5,15}{6,15}", "Figur", "Längd", "Bredd", "Höjd", "Mantelarea", "Begräns.area", "Volym");
							break;
						}
				}
				string frameLine = new string('-', text.Length);
				Console.WriteLine(frameLine);
				Console.WriteLine(text);
				Console.WriteLine(frameLine);
				Console.WriteLine("");
				for (int i = 0; i < shapes.Length; i++)
				{
					Console.WriteLine(shapes[i].ToString("R"));
				}
			}
		}
	}
}
