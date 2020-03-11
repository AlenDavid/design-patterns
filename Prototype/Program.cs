using System;
using System.Collections.Generic;

namespace Prototype
{
	interface ISequence
	{
		Sequence Clone();
	}

	class Sequence : ISequence
	{
		public string Letter { get; }

		private Sequence(string letter) => Letter = letter;

		private const string A = "A";
		private const string C = "C";
		private const string G = "G";
		private const string T = "T";

		private static readonly Dictionary<string, Sequence> SequenceMap = new Dictionary<string, Sequence>
		{
			[A] = new Sequence(A),
			[C] = new Sequence(C),
			[G] = new Sequence(G),
			[T] = new Sequence(T)
		};

		public Sequence Clone() => this;

		public static Sequence GetSequence(string sequence)
		{
			if (SequenceMap.ContainsKey(sequence))
			{
				return SequenceMap[sequence].Clone();
			}

			return null;
		}

		override
		public string ToString() => Letter;
	}

	class Cell
	{
		private List<Sequence> DNA = new List<Sequence>();

		public void AddSequenceToDNA(string sequence)
		{
			DNA.Add(Sequence.GetSequence(sequence));
		}

		public void Print()
		{
			DNA.ForEach(i => Console.Write(i));
			Console.WriteLine();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Cell cell = new Cell();
			cell.AddSequenceToDNA("A");
			cell.AddSequenceToDNA("C");
			cell.AddSequenceToDNA("G");
			cell.AddSequenceToDNA("G");
			cell.AddSequenceToDNA("T");
			cell.AddSequenceToDNA("T");
			cell.AddSequenceToDNA("A");

			cell.Print();
		}
	}
}
