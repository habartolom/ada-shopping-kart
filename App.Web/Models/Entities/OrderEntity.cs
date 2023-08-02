namespace App.Web.Models.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public int Items { get; set; }
        public Guid UserId {  get; set; }
        public virtual ICollection<OrderProductEntity> Products { get; } = new List<OrderProductEntity>();
        public virtual UserEntity User { get; set; } = null!;
    }
}
