namespace App.Web.Models.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string? PasswordHash { get; set; }
        public string? PasswordSalt { get; set; }
        public bool IsActive { get; set; }
        public Guid RoleId { get; set; }
        public Guid PersonId { get; set; }
        public virtual RoleEntity Role { get; set; } = null!;
        public virtual PersonEntity Person { get; set; } = null!;
        public virtual ICollection<OrderEntity> Orders { get; } = new List<OrderEntity>();
    }
}
