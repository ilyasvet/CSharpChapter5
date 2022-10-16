using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5_3
{
	abstract class Shape
	{

		protected char sym;
		protected int height;
		protected int pos;
		protected int indentHigh;
		protected int indentLow;

		public char Sym
		{
			get => sym;
			set => sym = value;
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
			for (int i = 0; i < 115; i++)
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
		static void Main(string[] args)
		{
			List<Shape> list = new List<Shape>();
			for (int i = 6; i < 9; i++)
			{
				list.Add(new Square(i));
				list.Add(new Treangle(i));
			}
			char[] syms = new char[6] { '@', '#', '$', '%', '^', '&' };
			foreach (Shape item in list)
			{
				int iter = list.IndexOf(item);
				item.ChangePos(iter, 3, 3);
				item.Sym=syms[iter];
				item.Draw();
				Console.WriteLine();
			}
			list[0].Move(3,-5,3);
			list[0].ChangePos(2,1,0);
			list[0].Draw();
			Console.ReadLine();




			////треугольник 1
			//Console.WriteLine();
			//for (int i = 0; i < size; i++)
			//{
			//	for (int j = 0; j < size - i; j++)
			//	{
			//		Console.Write(symbol);
			//	}
			//	Console.WriteLine();
			//}
			////треугольник 2
			//Console.WriteLine();
			//for (int i = 0; i < size; i++)
			//{
			//	for (int j = size - i - 1; j < size; j++)
			//	{
			//		Console.Write(symbol);
			//	}
			//	Console.WriteLine();
			//}
			////треугольник 3
			//Console.WriteLine();
			//for (int i = 0; i < size; i++)
			//{
			//	for (int j = size - i; j < size; j++)
			//	{
			//		Console.Write(space);
			//	}
			//	for (int j = 0; j < size - i; j++)
			//	{
			//		Console.Write(symbol);
			//	}
			//	Console.WriteLine();
			//}
			////треугольник 4
			//Console.WriteLine();
			//for (int i = 0; i < size; i++)
			//{
			//	for (int j = size - i - 1; j < size; j++)
			//	{
			//		Console.Write(symbol);
			//	}
			//	for (int j = 0; j < size - i; j++)
			//	{
			//		Console.Write(space);
			//	}
			//	Console.WriteLine();
			//}
		}
	}
}
