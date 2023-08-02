namespace App.Web.Models.Contracts.Users
{
    public class LoginResponseContract
    {
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
