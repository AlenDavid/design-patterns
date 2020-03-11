using System;

namespace Bridge
{
	interface IEngineBridge
	{
		void SetEngine();
	}

	class GasEngine : IEngineBridge
	{
		public void SetEngine()
		{
			Console.WriteLine("Set gas engine!");
		}
	}

	class EletricEngine : IEngineBridge
	{
		public void SetEngine()
		{
			Console.WriteLine("Set eletric engine!");
		}
	}

	interface IEngine
	{
		void SetBridgeEngine();
	}

	class Engine : IEngine
	{
		private IEngineBridge _Bridge;

		public Engine(IEngineBridge bridge) => _Bridge = bridge;

		public void SetBridgeEngine() => _Bridge.SetEngine();
	}

	class Program
	{
		static void Main(string[] args)
		{
			Engine carEngine1 = new Engine(new EletricEngine());
			Engine carEngine2 = new Engine(new GasEngine());

			carEngine1.SetBridgeEngine();
			carEngine2.SetBridgeEngine(); 
		}
	}
}
