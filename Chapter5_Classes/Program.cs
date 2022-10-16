using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5_Classes
{
	class Program
	{
		static void SpeedUp(Car car)
		{
			car.Speed += 5;
		}

		static void Main(string[] args)
		{
			Car first = new Car();
			Car second = new Car("Vasik");
			Car third = new Car("Gelik", 10);
			Car fourth = new Car() { Name = "Lada", Speed = 20 };
			first.Info();
			second.Info();
			third.Info();
			fourth.Info();
			SpeedUp(third);
			third.Info();
		}
	}

	class Car
	{
		public string Name;
		public int Speed;
		public Car(string name, int speed)
		{
			Name = name;
			Speed = speed;
		}
		public Car(string name) : this(name, -1) { }
		public Car() : this("default", 0) { }
		public void Info()
		{
			Console.WriteLine($"{Name} moves with {Speed} MPH");
		}
	}
}
