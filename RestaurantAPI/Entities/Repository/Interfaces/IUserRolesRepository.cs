using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities.Repository.Interfaces
{
    public interface IUserRolesRepository
    {
        Task<IEnumerable<UserRoles>> GetAllUserRolesAsync();
        Task<User> GetUserRoleByIdAsync(Guid userId);
        void CreateUserRole(ref User user);
        Task UpdateUserAsync(User dbUser, User user);
    }
}
