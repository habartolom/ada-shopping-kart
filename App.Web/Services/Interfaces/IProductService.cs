using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResponseTypedContract<IEnumerable<OrderProductDto>>> GetAvailableProductsAsync();
        Task<ResponseTypedContract<OrderProductDto>> GetProductAsync(Guid productId);
        Task<ResponseTypedContract<OrderProductDto>> UpdateProductAsync([FromRoute] Guid productId);
    }
}
