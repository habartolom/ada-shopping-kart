using App.Web.Models.Entities;

namespace App.Web.Models.Dtos
{
    public class OrderDetailDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public int Items { get; set; }
        public ICollection<OrderProductDto> Products { get; set; } = new List<OrderProductDto>();
    }
}
