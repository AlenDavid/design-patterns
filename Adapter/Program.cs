using System;
using System.Collections.Generic;

namespace Adapter
{
	interface IControllerAdapter
	{
		void TurnOff();
		void TurnOn();
	}

	class TV
	{
		public void TurnOff()
		{
			Console.WriteLine("TV is off!");
		}

		public void TurnOn()
		{
			Console.WriteLine("TV is on!");
		}
	}

	class VideoGame
	{
		private bool _HasGame = false;

		public VideoGame(bool hasGame)
		{
			_HasGame = hasGame;
		}

		public void EjectGame()
		{
			Console.WriteLine("Ejecting game!");
		}
		public void TurnOff()
		{
			if (_HasGame)
			{
				EjectGame();
			}
			Console.WriteLine("Videogame is off!");
		}

		public void TurnOn()
		{
			Console.WriteLine("VideoGame is on!");
		}
	}

	class TVControllerAdapter : IControllerAdapter
	{
		private TV tv;

		public TVControllerAdapter()
		{
			tv = new TV();
		}

		public void TurnOff() => tv.TurnOff();
		public void TurnOn() => tv.TurnOn();
	}

	class VideoGameControllerAdapter : IControllerAdapter
	{
		VideoGame videoGame;

		public VideoGameControllerAdapter()
		{
			videoGame = new VideoGame(true);
		}

		public void TurnOff() => videoGame.TurnOff();
		public void TurnOn() => videoGame.TurnOn();
	}

	class SmartController
	{
		private List<IControllerAdapter> list = new List<IControllerAdapter>();

		public void AddControllerAdapter(IControllerAdapter adapter) => list.Add(adapter);

		public void TurnOff(int pos) => list[pos].TurnOff();
		public void TurnOn(int pos) => list[pos].TurnOn();
	}

	class Program
	{
		static void Main(string[] args)
		{
			SmartController smart = new SmartController();
			smart.AddControllerAdapter(new VideoGameControllerAdapter());
			smart.AddControllerAdapter(new TVControllerAdapter());

			Console.WriteLine("Turning on all devices!");

			smart.TurnOn(0);
			smart.TurnOn(1);

			Console.WriteLine("Turning off all devices!");

			smart.TurnOff(0);
			smart.TurnOff(1);

		}
	}
}
