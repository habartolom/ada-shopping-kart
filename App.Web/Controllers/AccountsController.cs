using App.Web.Models;
using App.Web.Models.Contracts.Users;
using App.Web.Models.Enums;
using App.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequestContract loginRequest)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.LogUserAsync(loginRequest);
                if (response.Header.Code.Equals(HttpCodeEnum.Ok))
                    return View("Views/Home/Index.cshtml");
                else
                {
                    ModelState.AddModelError(string.Empty, response.Header.Message);
                    return View(loginRequest);
                }
            }
            return View(loginRequest);
        }
    }
}
