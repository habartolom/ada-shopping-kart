using System.ComponentModel.DataAnnotations;

namespace App.Web.Models.Contracts.Users
{
    public class LoginRequestContract
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
