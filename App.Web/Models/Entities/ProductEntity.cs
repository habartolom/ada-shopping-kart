namespace App.Web.Models.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = null;
        public virtual ICollection<OrderProductEntity> Orders { get; } = new List<OrderProductEntity>();

    }
}
