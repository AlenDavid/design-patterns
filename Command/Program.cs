using System;

namespace Command
{
	class Firearm
	{
		public int bulletsCount;
		public int bulletsMax;
		public bool canFire
		{
			get { return bulletsCount > 0; }

		}

		public Firearm(int bullets)
		{
			bulletsCount = bullets;
			bulletsMax = bullets;
		}

		public void Reload()
		{
			bulletsCount = bulletsMax;
			Console.WriteLine("Reloaded!");
		}
		public void Fire()
		{
			if (bulletsCount > 0)
			{
				bulletsCount--;
				Console.WriteLine("Fired!");
			}
			else
			{
				Console.WriteLine("Could not fire 'cause there is no bullets!");
			}
		}
	}

	class Command
	{
		public void Execute(Action action)
		{
			action.Invoke();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Firearm firearm = new Firearm(9);
			Command command = new Command();

			for (int i = 0; i < 10; i++)
			{
				command.Execute(firearm.Fire);
			}

			command.Execute(firearm.Reload);
		}
	}
}