using App.Web.Models.Contracts.Orders;
using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;

namespace App.Web.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseTypedContract<OrderDetailDto>> CreateOrderAsync(IEnumerable<ProductRequestContract> products);
        Task<ResponseTypedContract<OrderDetailDto>> GetOrderAsync(Guid orderId);
        ResponseTypedContract<IEnumerable<OrderDto>> GetOrders(Guid userId);
    }
}
