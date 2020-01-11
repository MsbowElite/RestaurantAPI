using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Entities.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities.Repository
{
    public class DishRepository : RepositoryBase<Dish>, IDishRepository
    {
        public DishRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<IEnumerable<Dish>> GetDishesAsync()
        {
            return await ListAll().OrderByDescending(o => o.CreatedAt).ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetDishesByMenuAsync(Guid menuId)
        {
            return await ListByCondition(o => o.MenuDishes.Any(a => a.MenuId == menuId && a.DeletedAt == null)).OrderByDescending(o => o.CreatedAt).ToListAsync();
        }

        public async Task<Dish> GetDishByIdWithIngredientsAsync(Guid companyDishId)
        {
            return await ApplicationDbContext.Dish.Include(Dish => Dish.DishIngredients)
                .SingleOrDefaultAsync(Dish => Dish.Id.Equals(companyDishId) && Dish.DeletedAt == null);
        }

        public async Task<Dish> GetDishByIdAsync(Guid companyDishId)
        {
            return await FindByConditionAsync(Dish => Dish.Id.Equals(companyDishId) && Dish.DeletedAt == null);
        }

        public async Task CreateDishAsync(Dish companyDish)
        {
            companyDish.CreatedAt = DateTime.UtcNow;
            Create(companyDish);
            await SaveAsync();
        }

        public async Task UpdateDishAsync(Dish companyDish)
        {
            companyDish.UpdatedAt = DateTime.UtcNow;
            Update(companyDish);
            await SaveAsync();
        }

        public async Task DeleteDishAsync(Dish companyDish)
        {
            companyDish.DeletedAt = DateTime.UtcNow;
            Update(companyDish);
            await SaveAsync();
        }
    }
}
