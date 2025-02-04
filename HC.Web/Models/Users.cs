namespace HC.Web.Models
{
    public class Users
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;// Should be hashed and salted in production
    }
}
