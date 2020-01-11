using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities.Repository.Interfaces
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetMenusAsync();
        Task<Menu> GetMenuByIdAsync(Guid menuId);
        Task<Menu> GetMenuByIdWithDishesAsync(Guid menuId);
        Task CreateMenuAsync(Menu menu);
        Task UpdateMenuAsync(Menu menu);
        Task DeleteMenuAsync(Menu menu);
    }
}
