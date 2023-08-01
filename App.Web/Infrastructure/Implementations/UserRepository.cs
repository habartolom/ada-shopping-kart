using App.Web.Infrastructure.Interfaces;
using App.Web.Models.Entities;

namespace App.Web.Infrastructure.Implementations
{
    public class UserRepository : IUserRepository
    {
        public async Task<UserEntity> GetUserByUsername(string username)
        {
            UserEntity user = new UserEntity();
            return user;
        }
    }
}
