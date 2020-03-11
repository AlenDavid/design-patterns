using System;

namespace Singleton
{
	class Singleton
	{
		private static Singleton instance = new Singleton();
		public static Singleton Instance { get { return instance; } }

		private string title { get; set; } = "The Name of the Wind";
		public string Title { get => title; }

		private int numPages { get; set; } = 647;
		public int NumPages { get => numPages; }

		private int atPage { get; set; } = 502;
		public int AtPage { get => atPage; }

		public void SetBook(string name, int numPages)
		{
			title = name;
			this.numPages = numPages;
			this.atPage = 0;
		}

		private Singleton()
		{
			Singleton.instance = this;
		}
	}

	class BookReader
	{
		public void SetBook(string name, int bookPages)
		{
			Singleton instance = Singleton.Instance;

			instance.SetBook(name, bookPages);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Singleton instance = Singleton.Instance;
			BookReader bookReader = new BookReader();

			Console.WriteLine("Reading book: " + instance.Title);
			Console.WriteLine("Now at page: " + instance.AtPage);

			bookReader.SetBook("How to cook in three steps", 230);

			Console.WriteLine("Reading new book!");

			Console.WriteLine("Reading book: " + instance.Title);
			Console.WriteLine("Now at page: " + instance.AtPage);
		}
	}
}
