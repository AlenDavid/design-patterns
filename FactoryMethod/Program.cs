using System;

namespace FactoryMethod
{
	interface IFactory<T>
	{
		T Make();
	}

	class Book
	{
		public Book() { }
		public string Title { get; set; }
	}

	class Pencil
	{
		public double Hardness { get; set; }
	}

	class BookFactory : IFactory<Book>
	{
		public Book Make()
		{
			return new Book
			{
				Title = "The Name of the Wind"
			};
		}
	}
	class PencilFactory : IFactory<Pencil>
	{
		public Pencil Make()
		{
			return new Pencil
			{
				Hardness = 2
			};
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			BookFactory bookFactory = new BookFactory();
			PencilFactory pencilFactory = new PencilFactory();

			Book ordinaryBook = bookFactory.Make();
			Pencil ordinaryPencil = pencilFactory.Make();

			Console.WriteLine("Book: " + ordinaryBook.Title);
			Console.WriteLine("Pencil hardness: " + ordinaryPencil.Hardness);
		}
	}
}
