namespace App.Web.Models.Contracts.Products
{
    public class ProductUpdateRequestContract
    {
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
