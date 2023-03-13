using Utils;

namespace Controllers
{
  public class Profiles
  {
    public static Models.Profiles CreateProfile(int userId, string profileType)
    {
      Models.Users user = Controllers.Users.GetUserById(userId.ToString());
      Models.Profiles profileUser = Models.Profiles.GetProfileByUser(user);

      if (profileUser != null)
      {
        throw new Exception(Messages.UserAlreadyHasProfile);
      }

      Enumerators.ProfileType profileTypeEnum = (Enumerators.ProfileType)int.Parse(profileType);
      Models.Profiles profile = new Models.Profiles(user, profileTypeEnum);
      return profile;
    }

    public static Models.Profiles UpdateProfile(string userId, string profileType)
    {
      Models.Users user = Controllers.Users.GetUserById(userId);
      Models.Profiles profileUser = Models.Profiles.GetProfileByUser(user);

      if (profileUser == null)
      {
        throw new Exception(Messages.UserDoesNotHaveProfile);
      }

      Enumerators.ProfileType profileTypeEnum = (Enumerators.ProfileType)int.Parse(profileType);
      Models.Profiles profile = Models.Profiles.UpdateProfile(profileUser, profileTypeEnum);
      return profile;
    }

    public static Models.Profiles DeleteProfile(string userId)
    {
      Models.Users user = Controllers.Users.GetUserById(userId.ToString());
      Models.Profiles profileUser = Models.Profiles.GetProfileByUser(user);

      if (profileUser == null)
      {
        throw new Exception(Messages.UserDoesNotHaveProfile);
      }

      Models.Profiles profile = Models.Profiles.DeleteProfile(profileUser);
      return profile;
    }

    public static int CountAdminProfiles()
    {
      return Models.Profiles.CountAdminProfiles();
    }

    public static int CountUserProfiles()
    {
      return Models.Profiles.CountUserProfiles();
    }

    public static Models.Profiles GetProfileById(int id)
    {
      return Models.Profiles.GetProfileById(id);
    }

    public static Utils.Enumerators.ProfileType GetProfileTypeByUser(int userId)
    {
      Models.Users user = Controllers.Users.GetUserById(userId.ToString());
      Models.Profiles profile = Models.Profiles.GetProfileByUser(user);
      return profile.ProfileType;
    }

    public static Models.Profiles GetProfileByUser(string userId)
    {
      Models.Users user = Controllers.Users.GetUserById(userId);
      return Models.Profiles.GetProfileByUser(user);
    }
  }
}