using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5_4
{
	class Person
	{
		private byte _age;

		public const double PI = 3.14;
		public readonly double E = 2.72;

		public string Name { get; set; }
		public byte Age
		{
			get => _age;
			set 
			{
				checked
				{
					_age = value > 0 ? value : 0;
				}
			}
		}
		public Person(string _Name = "", byte _Age = 0)
		{
			Name = _Name;
			Age = _Age;
			Console.WriteLine("Person");
		}
		public virtual void Info()
		{
			Console.WriteLine($"{Name}, {Age} years old");
		}
	}
	class Benefit
	{
		public int GetBenefitCost()
		{
			return 125;
		}
	}
	class Employee: Person
	{
		public Benefit Benefit { get; set; } = new Benefit();// делегация
		public int GetBenefit()				// добавление функционала для содержащегося объекта
		{                                   // делегация
			return Benefit.GetBenefitCost();
		}

		private int? _personalNumber;
		public int? PersonalNumber
		{
			get => _personalNumber;
			set
			{
				if ((value / 10000) < 10 && (value / 10000) != 0)
				{
					_personalNumber = value;
				}
				else
				{
					_personalNumber = null;
				}
			}
		}
		public Employee(string _Name = "", byte _Age = 0, int? numb = null) : base(_Name, _Age) //вызывается также конструктор родителя
		{
			PersonalNumber = numb;
		}
		public override string ToString()
		{
			return $"{Name} {Age} years old; Number: {PersonalNumber}\n";
		}
		public override sealed void Info()
		{
			base.Info();
			Console.WriteLine("This is Employee");
		}

	}

	class Program
	{
		static void Main(string[] args)
		{
			Person p = new Person() { Name = "35", Age = 234 };
			Person.PI.ToString(); // константное поле является неявно статическим
			Console.WriteLine(p.E.ToString()); // поля readonly не являются статическими. Можно задать в конструкторе

			Employee employee = new Employee("Kirya", 19, 14124); //вызывается также конструктор родителя
			Employee employee1 = new Employee("Danya", 18);
			Employee employee2 = new Employee("Vlad", 19, 141243);
			Console.WriteLine($"{employee}{employee1}{employee2}");
			Console.WriteLine(employee2.GetBenefit());
			employee.Info();
			Person pe = new Employee();
		}
	}
}
