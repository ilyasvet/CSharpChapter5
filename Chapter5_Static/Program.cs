using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.DateTime;

namespace Chapter5_Static
{
	class Program
	{
		static void Main(string[] args)
		{
			WriteLine(Now);
			Console.WriteLine(Credit.Percent);
			Credit c = new Credit();
			Console.WriteLine(Credit.Percent);
			Credit.Percent = 5;
			Console.WriteLine(Credit.Percent);
			c.GetPercent();
			c.SetPercent(0.4);
			Credit cc = new Credit();
			cc.GetPercent(); // percent являeтся общим членом всех объектов класса Credit 
			TimeT.DateTimeT();
		}

	}

	static class TimeT
	{
		public static void DateTimeT()
		{
			Console.WriteLine(DateTime.Now);
		}
	}

	class Credit
	{
		public static double Percent; // нельзя получать от объекта
		public void GetPercent()
		{
			Console.WriteLine(Percent);
		}
		public void SetPercent(double d)
		{
			Percent = d;
		}
		static Credit()
		{
			Console.WriteLine("Static"); // выполняется перед любым обычным конструктором
			Percent = 0.0006; // значение устанавливается 1 раз само, конструктор вызывается 1 раз
		}
		//public Credit()
		//{
		//	Console.WriteLine("Common");
		//	Percent = 0.000555; // значение будет збрасываться при создании нового объекта
		//}
	}
}
