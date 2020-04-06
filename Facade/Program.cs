using System;

namespace Facade
{
	class CharacterJob
	{
		public string JobName;

		public CharacterJob(string jobName) => JobName = jobName;

		public void Work() => Console.WriteLine("Working as " + JobName);
	}

	class CharacterClass
	{
		public string ClassName;

		public CharacterClass(string className) => ClassName = className;

		public void Attack() => Console.WriteLine("Attacking as " + ClassName);
	}

	class Character
	{
		public CharacterJob Job;
		public CharacterClass Class;

		public Character(string jobName, string className)
		{
			Job = new CharacterJob(jobName);
			Class = new CharacterClass(className);
		}

		public void Work() => Job.Work();
		public void Attack() => Class.Attack();
	}

	class Program
	{
		public static void Main(String[] args)
		{
			Character character = new Character("Smith", "Paladin");

			character.Work();
			character.Attack();
		}
	}
}