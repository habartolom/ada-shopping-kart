namespace App.Web.Models.Entities
{
    public class RoleEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<UserEntity> Users { get; } = new List<UserEntity>();
    }
}
