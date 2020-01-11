using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Entities.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities.Repository
{
    public class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            return await ListByCondition(ingredient => ingredient.DeletedAt == null).OrderByDescending(o => o.CreatedAt).ToListAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsByDishAsync(Guid dishId)
        {
            return await ListByCondition(o => o.DishIngredients.Any(a => a.DisheId == dishId && a.DeletedAt == null)).OrderByDescending(o => o.CreatedAt).ToListAsync();
        }

        public async Task<Ingredient> GetIngredientByIdAsync(Guid ingredientId)
        {
            return await FindByConditionAsync(ingredient => ingredient.Id.Equals(ingredientId) && ingredient.DeletedAt == null);
        }

        public async Task CreateIngredientAsync(Ingredient ingredient, Guid userId)
        {
            ingredient.UserId = userId;
            ingredient.CreatedAt = DateTime.UtcNow;
            Create(ingredient);
            await SaveAsync();
        }

        public async Task UpdateIngredientAsync(Ingredient newIngredient, Ingredient ingredient)
        {
            ingredient.Description = newIngredient.Description;
            ingredient.Name = newIngredient.Name;
            ingredient.UpdatedAt = DateTime.UtcNow;
            Update(ingredient);
            await SaveAsync();
        }

        public async Task DeleteIngredientAsync(Ingredient ingredient)
        {
            ingredient.DeletedAt = DateTime.UtcNow;
            Update(ingredient);
            await SaveAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsExcludeByDishIdAsync(Guid dishId)
        {
            return await ListByCondition(o => !o.DishIngredients.Any(a => a.DisheId == dishId) && o.DeletedAt == null).OrderByDescending(o => o.CreatedAt).ToListAsync();
        }
    }
}
