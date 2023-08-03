using App.Web.Models;
using App.Web.Models.Enums;
using App.Web.Services.Implementations;
using App.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static App.Web.Models.Constants.Constants;

namespace App.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IProductService productService, IUserService userService, ILogger<HomeController> logger)
        {
            _productService = productService;
            _userService = userService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var userIdAdmin = User.IsInRole(Roles.Admin);
            if (!userIdAdmin)
            {
                var productsResponse = await _productService.GetAvailableProductsAsync();
                if (productsResponse.Header.Code.Equals(HttpCodeEnum.Ok))
                {
                    return View("User", productsResponse.Data);
                }
            }
            else
            {
                var regularUsersResponse = _userService.GetAllRegularUsers();
                if (regularUsersResponse.Header.Code.Equals(HttpCodeEnum.Ok))
                {
                    return View("Admin", regularUsersResponse.Data);
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}