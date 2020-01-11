using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Areas.Ingredients.Controllers
{
    public partial class IngredientsController
    {
        [HttpGet("{id}")]
        [Authorize(StaticRoles.Customer)]
        [ProducesResponseType(typeof(IngredientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var ingredient = await _rw.Ingredient.GetIngredientByIdAsync(id);

                if (ingredient == null)
                {
                    return NotFound();
                }

                var ingredientMap = _mapper.Map<Entities.Ingredient, IngredientDTO>(ingredient);
                return Ok(ingredientMap);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
