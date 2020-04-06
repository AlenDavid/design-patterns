using System;

namespace ChainOfResponsibility
{
	class Beer
	{
		public int ibu = 0;
		public double alcContent = 0;
		string name;

		public Beer(string name) => this.name = name;

		public override string ToString()
		{ return name + "=> Ibu: " + ibu + " Alc%: " + alcContent; }

	}

	class Fermentation
	{
		double alcContent;

		public Fermentation(double alcContent) => this.alcContent = alcContent;
		public Beer Process(Beer beer)
		{
			beer.alcContent += alcContent;
			return beer;
		}
	}

	class Maturation
	{
		int ibu;

		public Maturation(int ibu) => this.ibu = ibu;

		public Beer Process(Beer beer)
		{
			beer.ibu += ibu;
			return beer;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Beer pilsen = new Maturation(50).Process(new Fermentation(8.2).Process(new Beer("Ipa")));

			Console.WriteLine(pilsen);
		}
	}
}
