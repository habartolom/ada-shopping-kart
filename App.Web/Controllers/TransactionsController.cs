using App.Web.Models.Enums;
using App.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly IOrderService _orderService;

        public TransactionsController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index(Guid userId)
        {
            var ordersResponse = _orderService.GetOrders(userId);
            if (ordersResponse.Header.Code.Equals(HttpCodeEnum.Ok))
            {
                return View(ordersResponse.Data);
            }
            return View();
        }

        public async Task<IActionResult> Detail(Guid orderId)
        {
            var orderDetailResponse = await _orderService.GetOrderAsync(orderId);
            if (orderDetailResponse.Header.Code.Equals(HttpCodeEnum.Ok))
            {
                return View(orderDetailResponse.Data);
            }
            return View();
        }
    }
}
