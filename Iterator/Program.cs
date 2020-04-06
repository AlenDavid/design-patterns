using System;

namespace Iterator
{
	interface Imove<T>
	{
		T Next();
		T Previous();
	}

	class Channel
	{
		public string Name;
		public int ChannelNumber;

		public Channel(string name, int number)
		{
			Name = name;
			ChannelNumber = number;
		}

		public override string ToString() => "Watching at " + ChannelNumber + ": " + Name;
	}

	class TV : Imove<Channel>
	{
		private int index = 0;
		private Channel[] channels;

		public TV(Channel[] channels)
		{
			this.channels = channels;
			Console.WriteLine(channels[0]);
		}

		public Channel Next()
		{
			if (index < (channels.Length - 1))
			{
				index++;
			}
			else
			{
				index = 0;
			}

			Console.WriteLine(channels[index]);
			return channels[index];
		}

		public Channel Previous()
		{
			if (index > 0)
			{
				index--;
			}
			else
			{
				index = channels.Length - 1;
			}

			Console.WriteLine(channels[index]);
			return channels[index];
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			TV tv = new TV(new Channel[] { new Channel("Globo", 12), new Channel("SBT", 10), new Channel("Band", 15), new Channel("Record", 9) });

			tv.Next();
			tv.Next();
			tv.Next();
			tv.Previous();
			tv.Previous();
			tv.Next();
			tv.Next();
			tv.Previous();
			tv.Previous();
			tv.Previous();
			tv.Previous();
		}
	}
}
