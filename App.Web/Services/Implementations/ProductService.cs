using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;
using App.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Services.Implementations
{
    public class ProductService : IProductService
    {
        public async Task<ResponseTypedContract<IEnumerable<OrderProductDto>>> GetAvailableProductsAsync()
        {
            var response = new ResponseTypedContract<IEnumerable<OrderProductDto>>();
            return response;
        }

        public async Task<ResponseTypedContract<OrderProductDto>> GetProductAsync(Guid productId)
        {
            var response = new ResponseTypedContract<OrderProductDto>();
            return response;
        }

        public async Task<ResponseTypedContract<OrderProductDto>> UpdateProductAsync(Guid productId)
        {
            var response = new ResponseTypedContract<OrderProductDto>();
            return response;
        }
    }
}
