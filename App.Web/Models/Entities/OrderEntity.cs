namespace App.Web.Models.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public Guid UserId {  get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<ProductEntity> Products { get; } = new List<ProductEntity>();
        public virtual UserEntity User { get; set; } = null!;
    }
}
