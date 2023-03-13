using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Utils
{
  public class Utils
  {
    public static void isEmail(String email)
    {
      if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
      {
        throw new Exception(Messages.InvalidEmail);
      }
    }

    public static void isPassword(string password)
    {
      if (!Regex.IsMatch(password, @"^\d{8}$"))
      {
        throw new Exception(Messages.InvalidPassword);
      }
    }

    public static int GenerateHashCode(int hashValue)
    {
      unchecked // desabilita checagem de overflow de inteiros
      {
        int hash = (int)2166136261; // numero primo arbitrario para iniciar o hash
        hash = (hash * 16777619) ^ hashValue; // heuristica de Bob Jenskins para gerar hash
        return hash;
      }
    }

    public static byte[] Encrypt(string data, byte[] key) // AES Algorithm
    {
      byte[] dataBytes = Encoding.UTF8.GetBytes(data);

      using (Aes aesAlg = Aes.Create())
      {
        aesAlg.Key = key;
        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        using (MemoryStream msEncrypt = new MemoryStream())
        {
          using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
          {
            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            {
              swEncrypt.Write(data);
            }
            return msEncrypt.ToArray();
          }
        }
      }
    }

    public static string GenerateAccessToken(string userInfo)
    {
      Enumerators.RandomKeys keyEnum = (Enumerators.RandomKeys)new Random().Next(1, 5); // busca uma palavra aleatória para ser a chave de criptografia
      byte[] key = Encoding.UTF8.GetBytes(keyEnum.ToString());
      string tokenPt1 = Encoding.UTF8.GetString(Encrypt(userInfo, key));
      string tokenPt2 = GenerateHashCode(DateTime.Now.GetHashCode()).ToString();

      return tokenPt1 + "-" + tokenPt2;
    }
  }

  public class Enumerators
  {
    public enum ProfileType
    {
      Admin = 1,
      User = 2
    }

    public enum UserFields
    {
      Name = 1,
      Email = 2,
      Password = 3
    }

    public enum SessionFields
    {
      Token = 1,
      CreatedDate = 2,
      ExpirationDate = 3
    }

    public enum RandomKeys
    {
      Galaxy = 1,
      Surreptitious = 2,
      Whimsical = 3,
      Pulchritudinous = 4,
      Ubiquitous = 5
    }
  }

  public class Messages
  {
    public static string InvalidEmail = "Invalid email address";
    public static string InvalidPassword = "Password must contain only numbers.";
    public static string IncorrectPassword = "Password is incorrect.";
    public static string UserAlreadyHasProfile = "User already has a profile.";
    public static string UserDoesNotHaveProfile = "User does not have a profile.";
    public static string UserNotFound = "User not found.";
    public static string SessionNotFound = "Session not found.";
    public static string SessionExpired = "Session expired.";
    public static string SessionInvalid = "Session invalid.";
    public static string SessionCreated = "Session created.";
    public static string SessionDeleted = "Session deleted.";
  }
}