using Utils;
using System;

namespace Views
{
  public class ProfilesViews
  {
    public static void CreateProfile()
    {
      Console.WriteLine(" ======== C R E A T E  P R O F I L E ======== ");
      Console.WriteLine(" Enter the user id to create a profile ");
      Console.Write(" > ");
      string userId = Console.ReadLine();
      Models.Users user = Controllers.Users.GetUserById(userId);

      Console.WriteLine(" USER: " + user.Name);
      Console.WriteLine(" PROFILE TYPE ");
      Console.WriteLine(" 1 - ADMIN ");
      Console.WriteLine(" 2 - USER ");
      Console.Write(" > ");
      string option = Console.ReadLine();
      Models.Profiles profile = Controllers.Profiles.CreateProfile(user.Id, option);
      Console.WriteLine(Messages.ProfileCreated);
    }

    public static void UpdateProfile()
    {
      Console.WriteLine(" ======== U P D A T E  P R O F I L E ======== ");
      Console.WriteLine(" Enter the user id to update a profile ");
      Console.Write(" > ");
      string userId = Console.ReadLine();

      Console.WriteLine(" PROFILE TYPE ");
      Console.WriteLine(" 1 - ADMIN ");
      Console.WriteLine(" 2 - USER ");
      Console.Write(" > ");
      string option = Console.ReadLine();
      Models.Profiles profile = Controllers.Profiles.UpdateProfile(userId, option);
      Console.WriteLine(Messages.ProfileUpdated);
    }

    public static void DeleteProfile()
    {
      Console.WriteLine(" ======== D E L E T E  P R O F I L E ======== ");
      Console.WriteLine(" Enter the user id to delete a profile ");
      Console.Write(" > ");
      string userId = Console.ReadLine();
      Models.Profiles profile = Controllers.Profiles.DeleteProfile(userId);
      Console.WriteLine(Messages.ProfileDeleted);
    }
    
  }
}