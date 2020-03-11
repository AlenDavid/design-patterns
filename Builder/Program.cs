using System;
using System.IO;

namespace Builder
{
	interface Input
	{
		string ReadLines();
	}

	interface IBuilder
	{
		Input Build(string args);
	}

	class Reader : IBuilder
	{
		public Input Build(string args)
		{
			if (args.Equals("txt"))
			{
				return new TXTReader();
			}
			return new CSVReader();
		}
	}

	class CSVReader : Input
	{
		public string ReadLines()
		{
			return "CSV!";
		}
	}

	class TXTReader : Input
	{
		public string ReadLines()
		{
			return "TXT!";
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			string arguments = "txt";
			Reader reader = new Reader();
			Input input = reader.Build(arguments);

			Console.WriteLine(input.ReadLines());
		}
	}
}
