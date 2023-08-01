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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //admin
        [AllowAnonymous]
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<IEnumerable<OrderDto>>> GetOrdersAsync([FromRoute] Guid userId)
        {
            return _orderService.GetOrdersAsync(userId);
        }

        //admin
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<OrderDto>> CreateOrderAsync([FromBody] OrderDto order)
        {
            return _orderService.CreateOrderAsync(order);
        }
    }
}
