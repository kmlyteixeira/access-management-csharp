using System.Text;
using Repository;
using Utils;
using System;
using System.Collections.Generic;

namespace Controllers
{
  public class Sessions
  {
    public static Models.Sessions Login(string email, string password)
    {
      Models.Sessions session = null;
      Models.Users user = Controllers.Users.GetUserByEmail(email);
      if (user == null)
      {
        throw new Exception(Messages.InvalidEmail);
      }

      if (Controllers.Users.UserAuth(email, password))
      {
        string accessToken = Utils.Utils.GenerateAccessToken(user.Name);
        DateTime createdDate = DateTime.Now;
        DateTime expirationDate = createdDate.AddHours(1);

        session = new Models.Sessions(user, accessToken, createdDate, expirationDate);
      }
      else
      {
        throw new Exception(Messages.InvalidPassword);
      }
      return session;
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
        return null;
      }

      if (session.ExpirationDate < DateTime.Now)
      {
        return null;
      }

      return session;
    }

  }
}