using App.Web.Models.Entities;

namespace App.Web.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserEntity> GetUserByUsername(string username);
    }
}
