using App.Web.Models.Constants;
using App.Web.Models.Contracts.Products;
using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;
using App.Web.Services.Implementations;
using App.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static App.Web.Models.Constants.Constants;

namespace App.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Available")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ResponseTypedContract<IEnumerable<ProductDto>>> GetAvailableProductsAsync()
        {
            return await _productService.GetAvailableProductsAsync();
        }


        [HttpGet("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ResponseTypedContract<ProductDto>> GetProductAsync([FromRoute] Guid productId)
        {
            return await _productService.GetProductAsync(productId);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ResponseTypedContract<ProductDto>> UpdateProductAsync([FromRoute] Guid productId, [FromBody] ProductUpdateRequestContract product)
        {
            return await _productService.UpdateProductAsync(productId, product);
        }
    }
}
