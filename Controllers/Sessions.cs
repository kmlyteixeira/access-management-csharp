using System.Text;
using Repository;
using Utils;

namespace Controllers
{
  public class Sessions
  {
    public static void Login(string email, string password)
    {
      Models.Users user = Controllers.Users.GetUserByEmail(email);
      if (user == null)
      {
        throw new Exception(Messages.InvalidEmail);
      }

      if (user.Password != Utils.Utils.GenerateHashCode(password.GetHashCode()).ToString())
      {
        throw new Exception(Messages.IncorrectPassword);
      }

      string accessToken = Utils.Utils.GenerateAccessToken(user.Name);
      DateTime createdDate = DateTime.Now;
      DateTime expirationDate = createdDate.AddHours(1);

      Models.Sessions session = new Models.Sessions(user, accessToken, createdDate, expirationDate);
    }

    public static void Logout(string id)
    {
      Models.Sessions session = Models.Sessions.GetSessionById(Int32.Parse(id));

      if (session == null)
      {
        throw new Exception(Messages.SessionNotFound);
      }

      Models.Sessions.DeleteSession(session);
    }

    public static Models.Sessions GetSessionById(int id)
    {
      return Models.Sessions.GetSessionById(id);
    }

    public static IEnumerable<Models.Sessions> GetAllSessions()
    {
      return Models.Sessions.GetAllSessions();
    }

    public static Models.Sessions GetActiveSession(Models.Users user)
    {
      Models.Sessions session = Models.Sessions.GetSessionByUser(user);

      if (session == null)
      {
        throw new Exception(Messages.SessionNotFound);
      }

      if (session.ExpirationDate < DateTime.Now)
      {
        throw new Exception(Messages.SessionExpired);
      }

      return session;
    }

  }
}