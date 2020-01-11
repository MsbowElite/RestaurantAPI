using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Models;

namespace RestaurantAPI.Entities.Repository.Interfaces
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> GetAllIngredientsAsync();
        Task<IEnumerable<Ingredient>> GetIngredientsExcludeByDishIdAsync(Guid dishId);
        Task<IEnumerable<Ingredient>> GetIngredientsByDishAsync(Guid dishId);
        Task<Ingredient> GetIngredientByIdAsync(Guid ingredientId);
        Task CreateIngredientAsync(Ingredient ingredient, Guid userId);
        Task UpdateIngredientAsync(Ingredient newIngredient, Ingredient ingredient);
        Task DeleteIngredientAsync(Ingredient ingredient);
    }
}
