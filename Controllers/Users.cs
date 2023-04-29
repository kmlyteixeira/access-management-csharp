using Repository;
using Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System;

namespace Controllers
{
  public enum Enumerators
  {
    UserFields,
    Name,
    Email,
    Password
  }

  public class Users
  {
    public static Models.Users CreateUser(string name, string email, string password)
    {
      isEmail(email);
      isPassword(password);
      string hashPassword = GenerateHashCode(password.GetHashCode()).ToString();

      return new Models.Users(name, email, hashPassword);
    }

    public static void UpdateUser(string id, string field, string value)
    {
      Models.Users user = GetUserById(id);
      Enumerators userField = (Enumerators)int.Parse(field);

      switch (userField)
      {
        case Enumerators.Name:
          user.Name = value;
          break;
        case Enumerators.Email:
          isEmail(value);
          user.Email = value;
          break;
        case Enumerators.Password:
          isPassword(value);
          string hashPassword = GenerateHashCode(value.GetHashCode()).ToString();
          user.Password = hashPassword;
          break;
      }

      Models.Users.UpdateUser(user, user.Name, user.Email, user.Password);
    }

    private static void isEmail (string email)
    {
      if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
      {
        throw new Exception(Messages.InvalidEmail);
      }
    }

    private static void isPassword (string password)
    {
      if (!Regex.IsMatch(password, @"^\d{8}$"))
      {
        throw new Exception(Messages.InvalidPassword);
      }
    }

    private static int GenerateHashCode(int hashValue)
    {
      unchecked // desabilita checagem de overflow de inteiros
      {
        int hash = (int)2166136261; // numero primo arbitrario para iniciar o hash
        hash = (hash * 16777619) ^ hashValue; // heuristica de Bob Jenskins para gerar hash
        return hash;
      }
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