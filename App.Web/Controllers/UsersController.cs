using App.Web.Models.Contracts.Login;
using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;
using App.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //admin - regular
        [AllowAnonymous]
        [HttpPost("signUp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<UserDto>> CreateUserAsync([FromBody] SignUpDto signUp)
        {
            return _userService.CreateUserAsync(signUp);
        }

        //admmin
        [AllowAnonymous]
        [HttpGet("Regular")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<IEnumerable<UserDto>>> GetAllRegularUsersAsync()
        {
            return _userService.GetAllRegularUsersAsync();
        }

        //admin
        [AllowAnonymous]
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<UserDto>> GetUserAsync([FromRoute] Guid userId)
        {
            return _userService.GetUserAsync(userId);
        }

        //admin - regular
        [HttpPost("logIn")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<LoginResponseContract>> LogUserAsync([FromBody] LoginRequestContract loginRequest)
        {
            return _userService.LogUserAsync(loginRequest);
        }
    }
}
