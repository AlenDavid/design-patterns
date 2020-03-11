using System;

namespace Decorator
{
	interface ISecurity
	{
		public void Guard();
	}

	class Door : ISecurity
	{
		public void Guard()
		{
			Console.WriteLine("Securiting door!");
		}
	}

	abstract class GeneralLock : ISecurity
	{
		private ISecurity _Security;
		public GeneralLock(ISecurity security) => _Security = security;

		public virtual void Guard() => _Security.Guard();
	}

	class PadLock : GeneralLock
	{
		public PadLock(ISecurity security) : base(security) { }

		public override void Guard()
		{
			TypePassword();
			base.Guard();
		}

		private void TypePassword() => Console.WriteLine("Typing password!");
	}

	class FingerprintLock : GeneralLock
	{
		public FingerprintLock(ISecurity security) : base(security) { }

		public override void Guard()
		{
			ScanFingerprint();
			base.Guard();
		}

		private void ScanFingerprint()
		{
			Console.WriteLine("Scanning Fingerprint!");
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			ISecurity security = new FingerprintLock(new PadLock(new Door()));

			security.Guard();
		}
	}
}
