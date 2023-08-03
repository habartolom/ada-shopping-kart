namespace App.Web.Models.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = null!;
    }
}
