using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;
using App.Web.Services.Implementations;
using App.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //regular - admin
        [AllowAnonymous]
        [HttpGet("Available")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<IEnumerable<ProductDto>>> GetAvailableProductsAsync()
        {
            return _productService.GetAvailableProductsAsync();
        }


        //admin
        [AllowAnonymous]
        [HttpGet("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<ProductDto>> GetProductsAsync([FromRoute] Guid productId)
        {
            return _productService.GetProductAsync(productId);
        }

        //admin
        [AllowAnonymous]
        [HttpPut("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<ProductDto>> UpdateProductsAsync([FromRoute] Guid productId)
        {
            return _productService.UpdateProductAsync(productId);
        }
    }
}
