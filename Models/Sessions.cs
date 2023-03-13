using Repository;

namespace Models
{
  public class Sessions
  {
    public int Id { get; set; }
    public virtual Users User { get; set; }
    public int UserId { get; set; }
    public string Token { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ExpirationDate { get; set; }

    public Sessions() { }

    public Sessions(Users user, string token, DateTime createdDate, DateTime expirationDate)
    {
      this.UserId = user.Id;
      this.User = user;
      this.Token = token;
      this.CreatedDate = createdDate;
      this.ExpirationDate = expirationDate;

      Context db = new Context();
      db.Sessions.Add(this);
      db.SaveChanges();
    }

    public static Sessions GetSessionById(int id)
    {
      Context db = new Context();

      return db.Sessions.Find(id);
    }

    public static Sessions GetSessionByUser(Users user)
    {
      Context db = new Context();

      return (from session in db.Sessions
              where session.UserId == user.Id
              orderby session.CreatedDate descending
              select session).First();
    }

    public static Sessions DeleteSession(Sessions session)
    {
      Context db = new Context();

      db.Sessions.Remove(session);
      db.SaveChanges();

      return session;
    }

    public static IEnumerable<Sessions> GetAllSessions()
    {
      Context db = new Context();

      return from session in db.Sessions
             select session;
    }

    public override string ToString()
    {
      return $"Id: {this.Id} - Token: {this.Token} - CreatedDate: {this.CreatedDate} - ExpirationDate: {this.ExpirationDate} - User: {Controllers.Users.GetUserById(this.UserId.ToString())}";
    }

  }
}