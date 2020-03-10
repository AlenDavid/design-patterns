using System;

namespace AbstractFactory
{
	interface ISugar
	{
		double GiveMoney();
	}

	interface ISugarFactory
	{
		ISugar CreateSugar(double money);
	}

	abstract class Sugar : ISugar
	{
		private double money = 0;

		public double Money
		{
			get { return money; }
		}

		public Sugar(double money) => this.money = money;

		public abstract double GiveMoney();

	}

	class SugarDaddy : Sugar
	{
		public SugarDaddy(double money) : base(money) { }

		override
		public double GiveMoney()
		{
			Console.WriteLine($"Daddy is giving {Money} to baby");
			return Money;
		}
	}

	class SugarMommy : Sugar
	{
		public SugarMommy(double money) : base(money) { }

		override
		public double GiveMoney()
		{
			Console.WriteLine($"Mommy is giving {Money} to baby");
			return Money;
		}
	}

	class DaddyFactory : ISugarFactory
	{
		public ISugar CreateSugar(double money) => new SugarDaddy(money: money);
	}

	class MommyFactory : ISugarFactory
	{
		public ISugar CreateSugar(double money) => new SugarMommy(money: money);
	}

	class Program
	{
		static void Main(string[] args)
		{
			var isDaddy = false;
			var initialMoney = 2000;
			ISugarFactory sugarFactory;

			if (isDaddy == true)
			{
				sugarFactory = new DaddyFactory();
			}
			else
			{
				sugarFactory = new MommyFactory();
			}

			ISugar sugar = sugarFactory.CreateSugar(initialMoney);
			sugar.GiveMoney();
		}
	}
}
