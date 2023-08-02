using App.Web.Models.Contracts.Response;
using App.Web.Models.Contracts.Users;
using App.Web.Models.Dtos;

namespace App.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseTypedContract<UserDto>> CreateUserAsync(SignUpDto signUp);
        ResponseTypedContract<IEnumerable<UserDto>> GetAllRegularUsers();
        Task<ResponseTypedContract<UserDto>> GetUserAsync(Guid userId);
        Task<ResponseTypedContract<LoginResponseContract>> LogUserAsync(LoginRequestContract loginRequest);
    }
}
