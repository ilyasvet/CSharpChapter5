using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5_3
{
	abstract class Command
	{
		static protected Dictionary<string, Shape> shapes = new Dictionary<string, Shape>();
		public abstract void Execute(List<string> _params);
		protected bool CheckArgc(List<string> _params, int need)
		{
			return _params.Count == need;
		}
		protected void WrongMessage()
		{
			Console.WriteLine("Wrong command");
		}
	}

	class ListCommand : Command
	{
		public override void Execute(List<string> _params)
		{
			if (CheckArgc(_params, 1))
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
				return;
			}
			WrongMessage();
		}
	}
	class CreateCommand : Command
	{
		public override void Execute(List<string> _params)
		{
			if (CheckArgc(_params, 4))
			{
				if (int.TryParse(_params[3], out int height))
				{
					string p = _params[1];
					string nameF = _params[2];
					if (p == "sq")
					{
						shapes.Add(nameF, new Square(height));
						return;
					}
					else if (p == "tr")
					{
						shapes.Add(nameF, new Treangle(height));
						return;
					}
				}
			}
			WrongMessage();
		}
	}
	class ShowCommand : Command
	{
		public override void Execute(List<string> _params)
		{
			if (CheckArgc(_params, 2))
			{
				string nameF = _params[1];
				if (shapes.ContainsKey(nameF))
				{
					shapes[nameF].Draw();
					return;
				}
				Console.WriteLine("No such shape");
				return;
			}
			WrongMessage();
		}
	}
	class MoveCommand : Command
	{
		public override void Execute(List<string> _params)
		{
			if (CheckArgc(_params, 5))
			{
				string nameF = _params[1];
				if (shapes.ContainsKey(nameF))
				{
					if (int.TryParse(_params[2], out int posX) &&
						int.TryParse(_params[3], out int pT) &&
						int.TryParse(_params[4], out int pB))
					{
						shapes[nameF].Move(posX, pT, pB);
						return;
					}
					WrongMessage();
					return;
				}
				Console.WriteLine("No such shape");
				return;
			}
			WrongMessage();
		}
	}
	class ScaleCommand : Command
	{
		public override void Execute(List<string> _params)
		{
			if (CheckArgc(_params, 3))
			{
				string nameF = _params[1];
				if (shapes.ContainsKey(nameF))
				{
					if (double.TryParse(_params[2], out double k))
					{
						shapes[nameF].Scale(k);
						return;
					}
					WrongMessage();
					return;
				}
				Console.WriteLine("No such shape");
				return;
			}
			WrongMessage();
		}
	}
}
