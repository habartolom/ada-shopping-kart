using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResponseTypedContract<IEnumerable<ProductDto>>> GetAvailableProductsAsync();
        Task<ResponseTypedContract<ProductDto>> GetProductAsync(Guid productId);
        Task<ResponseTypedContract<ProductDto>> UpdateProductAsync([FromRoute] Guid productId);
    }
}
