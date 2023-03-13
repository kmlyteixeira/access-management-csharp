using System;
using Utils;

namespace Views
{
  public class Home
  {
    public static void Render()
    {
      Console.WriteLine(" ======== A C C E S S  C O N T R O L  ======== ");
      Console.WriteLine(" = 1 - LOGIN   |  2 - REGISTER  |   3 - EXIT = ");
      Console.WriteLine(" ============================================= ");
      Console.Write(" > ");
      int option = Int32.Parse(Console.ReadLine());
      switch (option)
      {
        case 1:
          Views.SessionsViews.Login();
          break;
        case 2:
          Views.UsersViews.Register();
          break;
        case 3:
          Console.WriteLine(Messages.ExitSystem);
          break;
        default:
          Console.WriteLine(Messages.InvalidOption);
          break;
      }
    }

    public static void RenderAdmin(Models.Users user)
    {
      Console.WriteLine(" ======== HELLO, "+ user.Name +" ======== ");
      string option = "";
      do
      {
        Console.WriteLine(" ======== A D M I N  M E N U ======== ");
        Console.WriteLine(" 0 - LOGOUT ");
        Console.WriteLine(" 1 - CREATE PROFILE ");
        Console.WriteLine(" 2 - UPDATE PROFILE ");
        Console.WriteLine(" 3 - DELETE PROFILE ");
        Console.WriteLine(" 4 - DELETE USER ");
        Console.WriteLine(" 5 - UPDATE USER ");
        Console.WriteLine(" 6 - LIST USERS ");
        Console.WriteLine(" 7 - LIST ACTIVE SESSIONS ");
        Console.WriteLine(" > ");
        option = Console.ReadLine();
        switch (option)
        {
          case "0":
            Controllers.Sessions.Logout(user.Id.ToString());
            break;
          case "1":
            Views.ProfilesViews.CreateProfile();
            break;
          case "2":
            Views.ProfilesViews.UpdateProfile();
            break;
          case "3":
            Views.ProfilesViews.DeleteProfile();
            break;
          case "4":
            Views.UsersViews.DeleteUser();
            break;
          case "5":
            Views.UsersViews.UpdateUser();
            break;
          case "6":
            Views.UsersViews.ListUsers();
            break;
          case "7":
            Views.SessionsViews.ListSessions();
            break;
          default:
            Console.WriteLine(Messages.InvalidOption);
            break;
        }

      } while (option != "0");
    }

    public static void RenderUser(Models.Users user)
    {
      Console.WriteLine(" ======== HELLO, "+ user.Name +" ======== ");
      string option = "";
      Console.WriteLine(" ======== U S E R  M E N U ======== ");
      Console.WriteLine(" 0 - LOGOUT ");
      Console.WriteLine(" 1 - UPDATE MY USER ");
      Console.WriteLine(" > ");
      option = Console.ReadLine();
      switch (option)
      {
        case "0":
          Controllers.Sessions.Logout(user.Id.ToString());
          Console.WriteLine(Messages.ExitSystem);
          break;
        case "1":
          Views.UsersViews.UpdateUser();
          break;
        default:
          Console.WriteLine(Messages.InvalidOption);
          break;
      }
    }
  }
}