using App.Web.Models.Contracts.Products;
using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;

namespace App.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResponseTypedContract<IEnumerable<ProductDto>>> GetAvailableProductsAsync();
        Task<ResponseTypedContract<ProductDto>> GetProductAsync(Guid productId);
        Task<ResponseTypedContract<ProductDto>> UpdateProductAsync(Guid productId, ProductUpdateRequestContract product);
    }
}
