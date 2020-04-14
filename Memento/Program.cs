using System;

namespace Memento
{

  class Notation
  {
    public string Text = "Default";

    public void SetMemento(Memento memento) => Text = memento.Notation.Text;
    public Memento CreateMemento() => new Memento((Notation)this.MemberwiseClone());
  }

  class Memento
  {
    public Notation Notation;

    public Memento(Notation notation) => Notation = notation;

    public void Keep(Notation notation) => Notation = notation;
    public Notation Restore() => Notation;
  }

  class Program
  {
    static void Main(string[] args)
    {
      Notation notation = new Notation();
      Memento m1 = notation.CreateMemento();

      notation.Text = "Rychi";
      Memento m2 = notation.CreateMemento();

      notation.Text = "David";
      Memento m3 = notation.CreateMemento();

      Console.WriteLine(notation.Text);
      notation.SetMemento(m2);
      Console.WriteLine(notation.Text);
    }
  }
