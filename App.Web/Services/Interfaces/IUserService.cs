using App.Web.Models.Contracts.Login;
using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;

namespace App.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseTypedContract<UserDto>> CreateUserAsync(SignUpDto signUp);
        Task<ResponseTypedContract<IEnumerable<UserDto>>> GetAllRegularUsersAsync();
        Task<ResponseTypedContract<UserDto>> GetUserAsync(Guid userId);
        Task<ResponseTypedContract<LoginResponseContract>> LogUserAsync(LoginRequestContract loginRequest);
    }
}
