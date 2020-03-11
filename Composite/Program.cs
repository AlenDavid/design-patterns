using System;

namespace Composite
{
	class Container
	{
		public Container Child;

		public Container() => Child = null;

		public Container(Container child) => Child = child;

		override
		public string ToString()
		{
			if (Child == null)
			{
				return "An empty Container";
			}

			return "A Container with " + Child.ToString();
		}
	}

	class Text : Container
	{
		public string Str = "";

		public Text(string str) : base() => Str = str;

		override
		public string ToString()
		{
			if (Child == null)
			{
				return $"an empty Text called {Str}";
			}

			return $"a Text called {Str} with " + Child.ToString();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Container c1 = new Container();
			Text t1 = new Text("I'm Text Container");

			c1.Child = t1;

			Console.WriteLine(c1);
			Console.WriteLine(t1);
		}
	}
}
