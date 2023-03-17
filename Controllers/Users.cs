using Repository;
using Utils;
using System.Collections.Generic;
using System.Linq;

namespace Controllers
{
  public class Users
  {
    public static Models.Users CreateUser(string name, string email, string password)
    {
      Utils.Utils.isEmail(email);
      Utils.Utils.isPassword(password);
      string hashPassword = Utils.Utils.GenerateHashCode(password.GetHashCode()).ToString();

      return new Models.Users(name, email, hashPassword);
    }

    public static void UpdateUser(string id, string field, string value)
    {
      Models.Users user = GetUserById(id);
      Enumerators.UserFields userField = (Enumerators.UserFields)int.Parse(field);

      switch (userField)
      {
        case Enumerators.UserFields.Name:
          user.Name = value;
          break;
        case Enumerators.UserFields.Email:
          Utils.Utils.isEmail(value);
          user.Email = value;
          break;
        case Enumerators.UserFields.Password:
          Utils.Utils.isPassword(value);
          string hashPassword = Utils.Utils.GenerateHashCode(value.GetHashCode()).ToString();
          user.Password = hashPassword;
          break;
      }

      Models.Users.UpdateUser(user, user.Name, user.Email, user.Password);
    }

    public static void DeleteUser(string id)
    {
      Models.Users user = GetUserById(id);
      Models.Users.DeleteUser(user);
    }

    public static Models.Users GetUserById(string id)
    {
      return Models.Users.GetUserById(int.Parse(id));
    }

    public static Models.Users GetUserByEmail(string email)
    {
      return Models.Users.GetUserByEmail(email);
    }

    public static IEnumerable<Models.Users> GetAllUsers()
    {
      return Models.Users.GetAllUsers();
    }

    public static bool UserAuth(string email, string password)
    {
      Utils.Utils.isEmail(email);
      string hashPassword = Utils.Utils.GenerateHashCode(password.GetHashCode()).ToString();

      Context db = new Context();
      IEnumerable<Models.Users> users = db.Users.Where(u => u.Email == email && u.Password == hashPassword);
      
      if (users.Count() == 0)
      {
        return false;
      }
      
      return true;
    }
  }
}