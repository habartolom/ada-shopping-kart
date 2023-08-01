using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;
using App.Web.Services.Interfaces;

namespace App.Web.Services.Implementations
{
    public class OrderService : IOrderService
    {
        public async Task<ResponseTypedContract<OrderDto>> CreateOrderAsync(OrderDto order)
        {
            var response = new ResponseTypedContract<OrderDto>();
            return response;
        }

        public async Task<ResponseTypedContract<IEnumerable<OrderDto>>> GetOrdersAsync(Guid userId)
        {
            var response = new ResponseTypedContract<IEnumerable<OrderDto>>();
            return response;
        }
    }
}
