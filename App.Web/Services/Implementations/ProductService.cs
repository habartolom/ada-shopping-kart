using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;
using App.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Services.Implementations
{
    public class ProductService : IProductService
    {
        public async Task<ResponseTypedContract<IEnumerable<ProductDto>>> GetAvailableProductsAsync()
        {
            var response = new ResponseTypedContract<IEnumerable<ProductDto>>();
            return response;
        }

        public async Task<ResponseTypedContract<ProductDto>> GetProductAsync(Guid productId)
        {
            var response = new ResponseTypedContract<ProductDto>();
            return response;
        }

        public async Task<ResponseTypedContract<ProductDto>> UpdateProductAsync(Guid productId)
        {
            var response = new ResponseTypedContract<ProductDto>();
            return response;
        }
    }
}
