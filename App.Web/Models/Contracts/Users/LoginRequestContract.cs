namespace App.Web.Models.Contracts.Users
{
    public class LoginRequestContract
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
