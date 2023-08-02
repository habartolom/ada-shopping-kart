using App.Web.Models.Constants;
using App.Web.Models.Contracts.Orders;
using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;
using App.Web.Services.Implementations;
using App.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static App.Web.Models.Constants.Constants;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("User/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ResponseTypedContract<IEnumerable<OrderDto>> GetOrders([FromRoute] Guid userId)
        {
            return _orderService.GetOrders(userId);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<OrderDetailDto>> GetOrder([FromRoute] Guid orderId)
        {
            return _orderService.GetOrderAsync(orderId);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<OrderDetailDto>> CreateOrderAsync([FromBody] IEnumerable<ProductRequestContract> products)
        {
            return _orderService.CreateOrderAsync(products);
        }
    }
}
