namespace Models {
    public class Sessions {
        public int Id { get; set; }
        public virtual Users User { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Sessions() { }

        public Sessions(Users user, string token, DateTime createdDate, DateTime expirationDate) {
            this.UserId = user.Id;
            this.Token = token;
            this.CreatedDate = createdDate;
            this.ExpirationDate = expirationDate;
        }
    }
}