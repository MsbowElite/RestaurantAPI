using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid userId);
        Task CreateUser(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<User> GetUserAuthenticateAsync(string username, string password);
    }
}
