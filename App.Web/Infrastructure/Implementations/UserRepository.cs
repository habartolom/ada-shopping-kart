using App.Web.Infrastructure.Database.Context;
using App.Web.Infrastructure.Interfaces;
using App.Web.Models.Dtos;
using App.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using static App.Web.Models.Constants.Constants;

namespace App.Web.Infrastructure.Implementations
{
    public class UserRepository : IUserRepository
    {
        private DbContext _dbContext;
        private DbSet<UserEntity> _table;

        public UserRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<UserEntity>();
        }

        public async Task<UserEntity> CreateUserAsync(UserEntity user)
        {
            await _table.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public IEnumerable<UserDto> GetAllRegularUsers()
        {
            IEnumerable<UserDto> users = _table
                .Include(x => x.Person)
                .Where(x => x.RoleId.Equals(Roles.RegularId))
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    Name = x.Person.Name,
                    Username = x.Username,
                    Address = x.Person.Address,
                    Phone = x.Person.Phone
                })
                .AsEnumerable();

            return users;
        }

        public async Task<UserDto?> GetUser(Guid userId)
        {
            UserDto? user = await _table
                .Include(x => x.Person)
                .Where(x => x.Id.Equals(userId))
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    Name = x.Person.Name,
                    Username = x.Username,
                    Address = x.Person.Address,
                    Phone = x.Person.Phone
                })
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<UserEntity?> GetUserByUsernameAsync(string username)
        {
            UserEntity? user = await _table
                .Include(x => x.Person)
                .Include(x => x.Role)
                .Where(x => x.Username.Equals(username))
                .FirstOrDefaultAsync();
            return user;
        }
    }
}
