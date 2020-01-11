using RestaurantAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Areas.Ingredients.Controllers
{
    public partial class IngredientsController
    {
        [HttpGet("Dish/{dishId}")]
        [ProducesResponseType(typeof(IEnumerable<IngredientDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> IngredientsExcludeByDishId(Guid dishId)
        {
            try
            {
                var ingredients = await _rw.Ingredient.GetIngredientsExcludeByDishIdAsync(dishId);
                var ingredientsMap = _mapper.Map<IEnumerable<Entities.Ingredient>, IEnumerable<IngredientDTO>>(ingredients);
                return Ok(ingredientsMap);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
