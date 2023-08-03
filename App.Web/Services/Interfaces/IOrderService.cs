using App.Web.Models.Contracts.Products;
using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;

namespace App.Web.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseTypedErrorContract<OrderDetailDto, IEnumerable<ProductDto>>> CreateOrderAsync(IEnumerable<ProductRequestContract> requestedProducts);
        Task<ResponseTypedContract<OrderDetailDto>> GetOrderAsync(Guid orderId);
        ResponseTypedContract<IEnumerable<OrderDto>> GetOrders(Guid userId);
    }
}
