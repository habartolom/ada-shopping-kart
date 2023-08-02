using App.Web.Models.Dtos;
using App.Web.Models.Entities;

namespace App.Web.Infrastructure.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> AddProductsToOrder(IEnumerable<OrderProductEntity> orderProducts);
        Task<int> CreateOrderAsync(OrderEntity order);
        Task<OrderEntity?> GetOrderAsync(Guid orderId);
        IEnumerable<OrderDto> GetOrders(Guid userId);
    }
}
