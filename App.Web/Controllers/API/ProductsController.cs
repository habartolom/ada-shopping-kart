using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;
using App.Web.Services.Implementations;
using App.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers.API
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
        public Task<ResponseTypedContract<IEnumerable<OrderProductDto>>> GetAvailableProductsAsync()
        {
            return _productService.GetAvailableProductsAsync();
        }


        //admin
        [AllowAnonymous]
        [HttpGet("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<OrderProductDto>> GetProductsAsync([FromRoute] Guid productId)
        {
            return _productService.GetProductAsync(productId);
        }

        //admin
        [AllowAnonymous]
        [HttpPut("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<OrderProductDto>> UpdateProductsAsync([FromRoute] Guid productId)
        {
            return _productService.UpdateProductAsync(productId);
        }
    }
}
