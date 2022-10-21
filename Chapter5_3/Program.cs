using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5_3
{
	abstract class Shape
	{

		private char sym = '$';
		private int height;
		private int pos;
		private int indentHigh;
		private int indentLow;

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

		public void Scale(double k)
		{
			Height = (int)(k * double.Parse(Height.ToString()));
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

		public abstract void Draw(); //наследники обязаны определить этот метод
	}
	class Square : Shape
	{
		public Square(int height = 1)
		{
			Height = height;
		}
		public override void Draw()
		{
			WriteBorder();
			MoveY(IndentHigh);
			for (int i = 0; i < Height; i++)
			{
				MoveRight();
				for (int j = 0; j < Height; j++)
				{
					Console.Write(Sym);
				}
				Console.WriteLine();
			}
			MoveY(IndentLow);
			WriteBorder();
		}
	}
	class Treangle : Shape
	{
		public Treangle(int height = 1)
		{
			Height = height;
		}
		public override void Draw()
		{
			WriteBorder();
			MoveY(IndentHigh);
			for (int i = 0; i < Height; i++)
			{
				MoveRight();
				for (int j = 0; j < Height - i - 1; j++)
				{
					Console.Write(" ");
				}
				for (int j = 0; j < (i + 1) * 2; j++)
				{
					Console.Write(Sym);
				}
				for (int j = 0; j < Height - i - 1; j++)
				{
					Console.Write(" ");
				}
				Console.WriteLine();
			}
			MoveY(IndentLow);
			WriteBorder();

		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			List<Shape> list = new List<Shape>();
			
			Console.WriteLine("Enter \"list\" for watching list\n" +
				"Enter \"create sq/tr *name* *height*\"  to create new shape\n" +
				"Enter \"show *name*\" to draw shape\n" +
				"Enter \"move *name* *posX* *padding top* *padding bottom*\" to move shape\n" +
				"Enter \"scale *name* *double*\" to scale shape\n" +
				"Enter \"End\" for exit\n");

			Dictionary<string, Command> commands = new Dictionary<string, Command>()
			{
				{ "list", new ListCommand() },
				{ "create", new CreateCommand() },
				{ "show", new ShowCommand() },
				{ "move", new MoveCommand() },
				{ "scale", new ScaleCommand() },
			};

			string command = "";
			while (command.ToLower() != "end")
			{
				command = Console.ReadLine();
				List<string> parts = command.Split(' ').ToList();
				string commandName = parts[0].ToLower();
				commands.TryGetValue(commandName, out Command c);
				c?.Execute(parts);
			}
		}
	}
}
