using Utils;
using System;
using System.Linq;

namespace Views
{
  public class UsersViews
  {
    public static void Register()
    {
      Console.WriteLine(" ======== R E G I S T E R ======== ");
      Console.WriteLine(" NAME ");
      Console.Write(" > ");
      string name = Console.ReadLine();

      Console.WriteLine(" EMAIL ADRESS ");
      Console.Write(" > ");
      string email = Console.ReadLine();
      Utils.Utils.isEmail(email);

      Console.WriteLine(" PASSWORD (Password must have 8 digits, only numbers.) ");
      Console.Write(" > ");
      string password = Console.ReadLine();
      Utils.Utils.isPassword(password);

      Controllers.Users.CreateUser(name, email, password);

      Console.WriteLine(Messages.UserCreated);
      Views.SessionsViews.Login();
    }

    public static void DeleteUser()
    {
      Console.WriteLine(" ======== D E L E T E  U S E R ======== ");
      Console.WriteLine(" Enter the user id to delete a user ");
      Console.Write(" > ");
      string userId = Console.ReadLine();
      Controllers.Users.DeleteUser(userId);
      Console.WriteLine(Messages.UserDeleted);
    }

    public static void UpdateUser()
    {
      Console.WriteLine(" ======== U P D A T E  U S E R ======== ");
      Console.WriteLine(" Enter the user id to update a user ");
      Console.Write(" > ");
      string userId = Console.ReadLine();

      Console.WriteLine(" Enter the field to update ");
      Console.WriteLine(" 1 - NAME ");
      Console.WriteLine(" 2 - EMAIL ");
      Console.WriteLine(" 3 - PASSWORD ");
      Console.WriteLine(" > ");
      string option = Console.ReadLine();

      if (Enum.IsDefined(typeof(Enumerators.UserFields), option))
      {
        Console.WriteLine(" Enter the new value ");
        Console.Write(" > ");
        string value = Console.ReadLine();
        Controllers.Users.UpdateUser(userId, option, value);
      }
      else
      {
        Console.WriteLine(Messages.InvalidOption);
      }
    }

    public static void ListUsers()
    {
      Console.WriteLine(" ======== L I S T  U S E R S ======== ");
      Console.WriteLine(" Number of Admin Users: " + Controllers.Profiles.CountAdminProfiles().ToString());
      Console.WriteLine(" Number of Common Users: " + Controllers.Profiles.CountUserProfiles().ToString());
      Console.WriteLine(" List of Users:");
      Controllers.Users.GetAllUsers().ToList().ForEach(user => Console.WriteLine(user));
    }
  }
}