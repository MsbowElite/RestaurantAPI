using RestaurantAPI.Entities;
using RestaurantAPI.Entities.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface IDishService
    {
        Task<bool> AddIngredient(Guid dishId, Guid ingredientId);
        Task<int> RemoveIngredient(Guid dishId, Guid ingredientId);
    }
    public class DishService : IDishService
    {
        private readonly IRepositoryWrapper _rw;
        private readonly ApplicationDbContext _db;

        public DishService(ApplicationDbContext db, IRepositoryWrapper rw)
        {
            _rw = rw;
            _db = db;
        }

        public async Task<bool> AddIngredient(Guid dishId, Guid ingredientId)
        {
            var dish = await _rw.Dish.GetDishByIdWithIngredientsAsync(dishId);

            var dishIngredient = dish.DishIngredients.FirstOrDefault(f => f.IngredientId == ingredientId);
            if (dishIngredient != null)
                if (dishIngredient.DeletedAt == null)
                    throw new System.Exception("Ingredient already added");
                else
                {
                    dishIngredient.DeletedAt = null;
                    _db.DishIngredients.Update(dishIngredient);
                    await _rw.SaveChanges();
                    return true;
                }

            dish.DishIngredients.Add(new Entities.DishIngredients()
            { DisheId = dishId, IngredientId = ingredientId, CreatedAt = DateTime.UtcNow });
            await _rw.SaveChanges();

            return true;
        }

        public async Task<int> RemoveIngredient(Guid dishId, Guid ingredientId)
        {
            var dish = await _rw.Dish.GetDishByIdWithIngredientsAsync(dishId);

            var dishIngredient = dish.DishIngredients.FirstOrDefault(f => f.IngredientId == ingredientId);
            if (dishIngredient == null)
                throw new System.Exception("Ingredient does not exist");
            if (dishIngredient.DeletedAt != null)
                throw new System.Exception("Ingredient does not exist");

            dishIngredient.DeletedAt = DateTime.UtcNow;
            _db.DishIngredients.Update(dishIngredient);
            return await _db.SaveChangesAsync();
        }
    }
}
