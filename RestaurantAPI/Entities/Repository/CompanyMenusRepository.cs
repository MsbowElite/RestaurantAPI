using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Entities.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities.Repository
{
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<IEnumerable<Menu>> GetMenusAsync()
        {
            return await ListAll().OrderByDescending(o => o.CreatedAt).ToListAsync();
        }

        public async Task<Menu> GetMenuByIdAsync(Guid companyMenuId)
        {
            return await FindByConditionAsync(Menu => Menu.Id.Equals(companyMenuId) && Menu.DeletedAt == null);
        }

        public async Task<Menu> GetMenuByIdWithDishesAsync(Guid companyMenuId)
        {
            return await ApplicationDbContext.Menu.Include(Menu => Menu.MenuDishes)
                .SingleOrDefaultAsync(Menu => Menu.Id.Equals(companyMenuId) && Menu.DeletedAt == null);
        }

        public async Task CreateMenuAsync(Menu companyMenu)
        {
            companyMenu.CreatedAt = DateTime.UtcNow;
            Create(companyMenu);
            await SaveAsync();
        }

        public async Task UpdateMenuAsync(Menu companyMenu)
        {
            companyMenu.UpdatedAt = DateTime.UtcNow;
            Update(companyMenu);
            await SaveAsync();
        }

        public async Task DeleteMenuAsync(Menu companyMenu)
        {
            companyMenu.DeletedAt = DateTime.UtcNow;
            Update(companyMenu);
            await SaveAsync();
        }
    }
}
