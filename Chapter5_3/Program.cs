using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5_3
{
	abstract class Shape
	{

		protected char sym = '$';
		protected int height;
		protected int pos;
		protected int indentHigh;
		protected int indentLow;

		public char Sym
		{
			get => sym;
			set => sym = value;
		}

		public int Height
		{
			get => height;
			set
			{
				if (value >= 0)
				{
					height = value;
				}
				else
				{
					Console.WriteLine("Warning, property \"Pos\" wasn't changed");
				}
			}
		}

		public int Pos
		{
			get => pos;
			set
			{
				if (value >= 0)
				{
					pos = value;
				}
				else
				{
					Console.WriteLine("Warning, property \"Pos\" wasn't changed");
				}
			}
		}

		public int IndentHigh
		{
			get => indentHigh;
			set
			{
				if (value >= 0)
				{
					indentHigh = value;
				}
				else
				{

					Console.WriteLine("Warning, property \"IndentHigh\" wasn't changed");
				}
			}
		}

		public int IndentLow
		{
			get => indentLow;
			set
			{
				if (value >= 0)
				{
					indentLow = value;
				}
				else
				{
					Console.WriteLine("Warning, property \"IndentLow\" wasn't changed");
				}
			}
		}

		public void ChangePos(int ch, int h, int low)
		{
			Pos = ch;
			IndentHigh = h;
			IndentLow = low;
		}

		public void Move(int ch, int h, int low)
		{
			Pos += ch;
			IndentHigh += h;
			IndentLow += low;
		}

		protected void MoveRight()
		{
			for (int i = 0; i < pos; i++)
			{
				Console.Write('\t');
			}
		}
		protected void MoveY(int pos)
		{
			for (int i = 1; i <= pos; i++)
			{
				Console.WriteLine(i);
			}
		}
		protected void WriteBorder()
		{
			for (int i = 0; i < 114; i++)
			{
				if (i % 8 == 0)
				{
					Console.Write(i / 8);
				}
				else
				{
					Console.Write('-');
				}
				
			}
			Console.WriteLine();
		}

		public abstract void Draw();
		public abstract void Scale(double k);
	}
	class Square : Shape
	{
		public Square(int height = 1)
		{
			this.height = height;
		}
		public override void Draw()
		{
			WriteBorder();
			MoveY(indentHigh);
			for (int i = 0; i < height; i++)
			{
				MoveRight();
				for (int j = 0; j < height; j++)
				{
					Console.Write(sym);
				}
				Console.WriteLine();
			}
			MoveY(indentLow);
			WriteBorder();
		}
		public override void Scale(double k)
		{
			height = (int)(k * double.Parse(height.ToString()));
		}
	}
	class Treangle : Shape
	{
		public Treangle(int height = 1)
		{
			this.height = height;
		}
		public override void Draw()
		{
			WriteBorder();
			MoveY(indentHigh);
			Console.WriteLine();
			for (int i = 0; i < height; i++)
			{
				MoveRight();
				for (int j = 0; j < height - i - 1; j++)
				{
					Console.Write(" ");
				}
				for (int j = 0; j < (i + 1) * 2; j++)
				{
					Console.Write(sym);
				}
				for (int j = 0; j < height - i - 1; j++)
				{
					Console.Write(" ");
				}
				Console.WriteLine();
			}
			MoveY(indentLow);
			WriteBorder();

		}
		public override void Scale(double k)
		{
			height = (int)(k * double.Parse(height.ToString()));
		}
	}

	class Program
	{
		static void ErrorMessage()
		{
			Console.WriteLine("Wrong command");
		}

		static void ShowList(Dictionary<string, Shape> shapes)
		{
			Console.WriteLine("==========List of shapes===========");
			foreach (var shape in shapes)
			{
				Console.WriteLine($"Name - {shape.Key}\n" +
					$"Height - {shape.Value.Height}," +
					$" PosX - {shape.Value.Pos}," +
					$" PaddingTop - {shape.Value.IndentHigh}," +
					$" PaddingBottom - {shape.Value.IndentLow}," +
					$" Symbol - {shape.Value.Sym}");
			}
		}

		static void Main(string[] args)
		{
			List<Shape> list = new List<Shape>();
			Dictionary<string, Shape> shapes = new Dictionary<string, Shape>();
			
			Console.WriteLine("Enter \"list\" for watching list\n" +
				"Enter \"create sq/tr *name* *height*\"  to create new shape\n" +
				"Enter \"show *name*\" to draw shape\n" +
				"Enter \"move *name* *posX* *padding top* *padding bottom*\" to move shape\n" +
				"Enter \"scale *name* *double*\" to scale shape\n" +
				"Enter \"End\" for exit\n");
			
			string command = "";
			while (command.ToLower() != "end")
			{
				command = Console.ReadLine();
				List<string> parts = command.Split(' ').ToList();
				int argc = parts.Count;
				switch (parts[0].ToLower())
				{
					case "list":
						if (argc != 1)
							ErrorMessage();
						else
						{
							if (shapes.Count == 0)
							{
								Console.WriteLine("No shapes");
							}
							else
							{
								ShowList(shapes);
							}
						}
						break;
					case "create":
						if (argc != 4)
							ErrorMessage();
						else
						{
							if (int.TryParse(parts[3], out int height))
							{
								if (parts[1] == "sq")
								{
									shapes.Add(parts[2], new Square(height));
								}
								else if (parts[1] == "tr")
								{
									shapes.Add(parts[2], new Treangle(height));
								}
								else
								{
									ErrorMessage();
								}
							}
							else
							{
								ErrorMessage();
							}
						}
						break;
					case "show":
						if (argc != 2)
							ErrorMessage();
						else
						{
							if (shapes.ContainsKey(parts[1]))
							{
								shapes[parts[1]].Draw();
							}
							else
							{
								Console.WriteLine("No such shape");
							}
						}
						break;
					case "move":
						if (argc != 5)
							ErrorMessage();
						else
						{
							if (shapes.ContainsKey(parts[1]))
							{
								if (int.TryParse(parts[2], out int posX) &&
									int.TryParse(parts[3], out int pT) &&
									int.TryParse(parts[4], out int pB))
								{
									shapes[parts[1]].Move(posX, pT, pB);
								}
								else
								{
									ErrorMessage();
								}
							}
							else
							{
								Console.WriteLine("No such shape");
							}
						}
						break;
					case "scale":
						if (argc != 3)
							ErrorMessage();
						else
						{
							if (shapes.ContainsKey(parts[1]))
							{
								if (double.TryParse(parts[2], out double k))
								{
									shapes[parts[1]].Scale(k);
								}
								else
								{
									ErrorMessage();
								}
							}
							else
							{
								Console.WriteLine("No such shape");
							}
						}
						break;
					case "end":
						break;
					default:
						ErrorMessage();
						break;
				}
			}
		}
	}
}
