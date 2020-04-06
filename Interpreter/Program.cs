using System;

namespace Interpreter
{
	interface IInterpreter
	{
		string Interpret();
	}

	class Binary : IInterpreter
	{
		public string Context;

		public Binary(string context) => Context = context;

		public string Interpret()
		{
			int i = 0, sum = 0;
			foreach (char c in Context.ToCharArray())
			{
				if (c == '1')
				{
					sum += (int)Math.Pow(2, i);
				}

				i++;
			};
			return sum.ToString();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Binary bin = new Binary("11100101");
			string interpreted = bin.Interpret();

			Console.WriteLine(interpreted);
		}
	}
}
