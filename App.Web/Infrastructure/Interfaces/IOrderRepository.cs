using App.Web.Models.Contracts.Orders;
using App.Web.Models.Dtos;
using App.Web.Models.Entities;

namespace App.Web.Infrastructure.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> CreateOrderAsync(IEnumerable<ProductRequestContract> requestedProducts, Guid orderId, Guid userId);
        Task<OrderEntity?> GetOrderAsync(Guid orderId);
        IEnumerable<OrderDto> GetOrders(Guid userId);
    }
}
