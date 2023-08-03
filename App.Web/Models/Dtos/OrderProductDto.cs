namespace App.Web.Models.Dtos
{
    public class OrderProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; } = null!;
    }
}
