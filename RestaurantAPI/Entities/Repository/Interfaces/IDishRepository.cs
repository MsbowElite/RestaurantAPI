using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities.Repository.Interfaces
{
    public interface IDishRepository
    {
        Task<IEnumerable<Dish>> GetDishesAsync();
        Task<Dish> GetDishByIdAsync(Guid dishId);
        Task<IEnumerable<Dish>> GetDishesByMenuAsync(Guid menuId);
        Task<Dish> GetDishByIdWithIngredientsAsync(Guid dishId);
        Task CreateDishAsync(Dish dish);
        Task UpdateDishAsync(Dish dish);
        Task DeleteDishAsync(Dish dish);
    }
}
