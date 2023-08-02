namespace App.Web.Models.Entities
{
    public class OrderProductEntity
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public virtual OrderEntity Order { get; set; } = null!;
        public virtual ProductEntity Product { get; set; } = null!;
    }
}
