using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;

namespace App.Web.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseTypedContract<OrderDto>> CreateOrderAsync(OrderDto order);
        Task<ResponseTypedContract<IEnumerable<OrderDto>>> GetOrdersAsync(Guid userId);
    }
}
