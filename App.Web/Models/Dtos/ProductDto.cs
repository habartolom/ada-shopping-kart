namespace App.Web.Models.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Stock { get; set; }
    }
}
