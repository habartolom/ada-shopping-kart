namespace App.Web.Models.Contracts.Login
{
    public class LoginRequestContract
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
