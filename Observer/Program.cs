using System;
using System.Collections.Generic;

namespace Observer
{
  class Telephonist
  {
    public string Name;

    public Telephonist(string name) => Name = name;

    public void Answer() => Console.WriteLine($"Hello! I'm {Name}!");
  }

  class Telephone
  {
    public List<Telephonist> Telephonists;

    public Telephone() => Telephonists = new List<Telephonist>();

    public void Register(Telephonist telephonist) => Telephonists.Add(telephonist);

    public void Notify()
    {
      foreach (Telephonist telephonist in Telephonists)
      {
        telephonist.Answer();
      }
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Telephone phone = new Telephone();

      Telephonist t1 = new Telephonist("Rychi");
      Telephonist t2 = new Telephonist("Tati");
      Telephonist t3 = new Telephonist("Luiza");

      phone.Register(t1);
      phone.Register(t2);
      phone.Register(t3);

      phone.Notify();
    }
  }
}