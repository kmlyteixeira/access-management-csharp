using Repository;

namespace Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Users() { }

        public Users(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;

            Context db = new Context();
            db.Users.Add(this);
            db.SaveChanges();
        }

        public static Users GetUserById(int id)
        {
            Context db = new Context();

            try {
                db.Users.Find(id);
            } catch (Exception e) {
                throw new Exception("User not found: " + e.Message);
            }

            return db.Users.Find(id);
        }

        public static Users GetUserByEmail(string email)
        {
            Context db = new Context();

            return (from user in db.Users
                    where user.Email == email
                    select user).First();
        }

        public static IEnumerable<Users> GetAllUsers()
        {
            Context db = new Context();

            return from user in db.Users
                   select user;
        }

        public static Users UpdateUser(Users user, string name, string email, string password)
        {
            Context db = new Context();

            user.Name = name;
            user.Email = email;
            user.Password = password;

            db.SaveChanges();

            return user;
        }

        public static Users DeleteUser(Users user)
        {
            Context db = new Context();

            db.Users.Remove(user);
            db.SaveChanges();

            return user;
        }

        public override string ToString()
        {
            return $"Id: {this.Id} - Name: {this.Name} - Email: {this.Email} - Profile: {Models.Profiles.GetProfileByUser(this)}";
        }
    }
}