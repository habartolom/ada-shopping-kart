using App.Web.Models.Constants;
using App.Web.Models.Contracts.Response;
using App.Web.Models.Contracts.Users;
using App.Web.Models.Dtos;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("SignUp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<UserDto>> CreateUserAsync([FromBody] SignupRequestContract signUpRequest)
        {
            return _userService.CreateUserAsync(signUpRequest);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("Regular")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ResponseTypedContract<IEnumerable<UserDto>> GetAllRegularUsersAsync()
        {
            return _userService.GetAllRegularUsers();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<UserDto>> GetUserAsync([FromRoute] Guid userId)
        {
            return _userService.GetUserAsync(userId);
        }

        [AllowAnonymous]
        [HttpPost("LogIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ResponseTypedContract<LoginResponseContract>> LogUserAsync([FromBody] LoginRequestContract loginRequest)
        {
            return _userService.LogUserAsync(loginRequest);
        }
    }
}
