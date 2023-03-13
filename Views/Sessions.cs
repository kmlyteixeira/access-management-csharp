using Utils;

namespace Views
{
  public class SessionsViews
  {
    public static void Login()
    {
      Console.WriteLine(" ======== W E L C O M E  A G A I N ======== ");
      Console.WriteLine(" EMAIL ADRESS ");
      Console.Write(" > ");
      string email = Console.ReadLine();
      Models.Users user = Controllers.Users.GetUserByEmail(email);
      if (Controllers.Sessions.GetActiveSession(user) != null)
      {
        Console.WriteLine(Messages.UserAlreadyLogged);
        DefineProfile(user);
        return;
      }

      Console.WriteLine(" PASSWORD ");
      Console.Write(" > ");
      string password = Console.ReadLine();

      Controllers.Sessions.Login(email, password);
      DefineProfile(user);
    }

    private static void DefineProfile(Models.Users user)
    {
      if (Controllers.Profiles.GetProfileTypeByUser(user.Id) == Enumerators.ProfileType.Admin)
      {
        Views.Home.RenderAdmin(user);
      }
      else if (Controllers.Profiles.GetProfileTypeByUser(user.Id) == Enumerators.ProfileType.User)
      {
        Views.Home.RenderUser(user);
      } 
      else 
      {
        Console.WriteLine(Messages.UserDoesNotHaveProfile);
      }
    }

    public static void ListSessions()
    {
      Console.WriteLine(" ======== L I S T  S E S S I O N S ======== ");
      Controllers.Sessions.GetAllSessions().ToList().ForEach(session => Console.WriteLine(session));
    }
  }
}