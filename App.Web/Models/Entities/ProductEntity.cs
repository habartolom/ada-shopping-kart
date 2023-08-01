namespace App.Web.Models.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Stock { get; set; }
        public Guid OrderId { get; set; }
        public virtual OrderEntity Order { get; set; } = null!;
    }
}
