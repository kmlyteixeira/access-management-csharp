using Utils;

namespace Controllers 
{
    public class Profiles 
    {
        public static Models.Profiles CreateProfile(string userId, string profileType)
        {
            Models.Users user = Controllers.Users.GetUserById(userId);
            Models.Profiles profileUser = Models.Profiles.GetProfileByUser(user);
            
            if (profileUser != null)
            {
                throw new Exception("User already has a profile.");
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
                throw new Exception("User does not have a profile.");
            }

            Enumerators.ProfileType profileTypeEnum = (Enumerators.ProfileType)int.Parse(profileType);
            Models.Profiles profile = Models.Profiles.UpdateProfile(profileUser, profileTypeEnum);
            return profile;
        }

        public static Models.Profiles DeleteProfile(string userId)
        {
            Models.Users user = Controllers.Users.GetUserById(userId);
            Models.Profiles profileUser = Models.Profiles.GetProfileByUser(user);

            if (profileUser == null)
            {
                throw new Exception("User does not have a profile.");
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

        public static Models.Profiles GetProfileByUser(string userId)
        {
            Models.Users user = Controllers.Users.GetUserById(userId);
            return Models.Profiles.GetProfileByUser(user);
        }
    }
}