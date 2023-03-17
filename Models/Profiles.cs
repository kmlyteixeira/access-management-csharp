using Repository;
using Utils;
using System.Linq;

namespace Models
{
  public class Profiles
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual Users User { get; set; }
    public Enumerators.ProfileType ProfileType { get; set; }

    public Profiles() { }

    public Profiles(Users user, Enumerators.ProfileType profileType)
    {
      this.UserId = user.Id;
      this.ProfileType = profileType;

      Context db = new Context();
      db.Profiles.Add(this);
      db.SaveChanges();
    }

    public static Profiles GetProfileById(int id)
    {
      Context db = new Context();

      return db.Profiles.Find(id);
    }

    public static Profiles GetProfileByUser(Users user)
    {
      Context db = new Context();

      return (from profile in db.Profiles
              where profile.UserId == user.Id
              select profile).First();
    }

    public static int CountAdminProfiles()
    {
      Context db = new Context();

      return (from profile in db.Profiles
              where profile.ProfileType == Enumerators.ProfileType.Admin
              select profile).Count();
    }

    public static int CountUserProfiles()
    {
      Context db = new Context();

      return (from profile in db.Profiles
              where profile.ProfileType == Enumerators.ProfileType.User
              select profile).Count();
    }

    public static Profiles UpdateProfile(Profiles profile, Enumerators.ProfileType profileType)
    {
      Context db = new Context();

      profile.ProfileType = profileType;

      db.SaveChanges();

      return profile;
    }

    public static Profiles DeleteProfile(Profiles profile)
    {
      Context db = new Context();

      db.Profiles.Remove(profile);
      db.SaveChanges();

      return profile;
    }

    public override string ToString()
    {
      return this.ProfileType.ToString();
    }
  }
}