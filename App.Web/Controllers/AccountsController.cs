using App.Web.Models;
using App.Web.Models.Constants;
using App.Web.Models.Contracts.Users;
using App.Web.Models.Enums;
using App.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static App.Web.Models.Constants.Constants;

namespace App.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequestContract loginRequest, string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.LogUserAsync(loginRequest);
                if (response.Header.Code.Equals(HttpCodeEnum.Ok))
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, response.Data.Username),
                    new Claim(ClaimTypes.Role, response.Data.Role)
                };

                    await HttpContext.SignInAsync(Schemas.Cookies, new ClaimsPrincipal(new ClaimsIdentity(claims, Schemas.Cookies, ClaimTypes.Name, ClaimTypes.Role)));

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");   
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, response.Header.Message);
                    return View(loginRequest);
                }
            }
            return View(loginRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignupRequestContract signupRequest)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.CreateUserAsync(signupRequest);
                if (response.Header.Code.Equals(HttpCodeEnum.Ok))
                {
                    return Redirect("Login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, response.Header.Message);
                    return View(signupRequest);
                }
            }
            return View(signupRequest);
        }
    }
}
