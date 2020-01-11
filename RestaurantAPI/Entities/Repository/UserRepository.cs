using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await ListAll().OrderByDescending(o => o.CreatedAt).ToListAsync();
            return users.OrderBy(x => x.Id);
        }

        public async Task<User> GetUserAuthenticateAsync(string username, string password)
        {
            return await ApplicationDbContext.User.Include(user => user.UserRoles)
                .SingleOrDefaultAsync(o => string.Equals(o.Username, username, StringComparison.CurrentCultureIgnoreCase) && o.Password == password);
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            var user = await FindByConditionAsync(o => o.Id.Equals(userId));
            return user;
        }

        public async Task CreateUser(User user)
        {
            user.CreatedAt = DateTime.UtcNow;
            Create(user);
            await SaveAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            user.UpdatedAt = DateTime.UtcNow;
            Update(user);
            await SaveAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            user.DeletedAt = DateTime.UtcNow;
            Update(user);
            await SaveAsync();
        }
    }
}
