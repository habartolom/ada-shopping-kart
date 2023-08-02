using App.Web.Models.Dtos;
using App.Web.Models.Entities;

namespace App.Web.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> CreateUserAsync(UserEntity user);
        IEnumerable<UserDto> GetAllRegularUsers();
        Task<UserDto?> GetUser(Guid userId);
        Task<UserEntity> GetUserByUsernameAsync(string username);
    }
}
