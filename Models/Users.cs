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
        }
    }
}