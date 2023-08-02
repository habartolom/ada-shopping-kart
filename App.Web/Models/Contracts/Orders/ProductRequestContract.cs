namespace App.Web.Models.Contracts.Orders
{
    public class ProductRequestContract
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
