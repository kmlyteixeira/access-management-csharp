namespace Models
{
  public enum ProfileType
  {
    Admin = 1,
    User = 2
  }

  public class Profiles
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual Users User { get; set; }
    public ProfileType ProfileType { get; set; }

    public Profiles() { }
    
    public Profiles(int id, Users user, ProfileType profileType)
    {
      this.Id = id;
      this.UserId = user.Id;
      this.ProfileType = profileType;
    }
  }
}