using System;
using System.Collections.Generic;

namespace Mediator
{
  class User
  {
    public string Username;
    public List<Group> groups;

    public User(string username)
    {
      Username = username;
      groups = new List<Group>();
    }
  }

  abstract class Group
  {
    public string Groupname;
    public List<User> users;
  }

  class Administrators : Group
  {
    public Administrators()
    {
      Groupname = "Administrators";
      users = new List<User>();
    }
  }

  class Developers : Group
  {
    public Developers()
    {
      Groupname = "Developers";
      users = new List<User>();
    }

  }

  class Mediator
  {
    public Administrators admins = new Administrators();
    public Developers devs = new Developers();

    public void AddToAdministrators(User user) => admins.users.Add(user);
    public void AddToDevelopers(User user) => devs.users.Add(user);
  }

  class Program
  {
    static void Main(string[] args)
    {
      Mediator mediator = new Mediator();

      User david = new User("alendavid");
      User felipe = new User("lipefe");
      User iago = new User("iago");

      mediator.AddToAdministrators(david);
      mediator.AddToAdministrators(iago);

      mediator.AddToDevelopers(david);
      mediator.AddToDevelopers(felipe);

      foreach (User user in mediator.admins.users)
        Console.WriteLine("Admin: " + user.Username);

      foreach (User user in mediator.devs.users)
        Console.WriteLine("Devs: " + user.Username);

    }
  }
}
