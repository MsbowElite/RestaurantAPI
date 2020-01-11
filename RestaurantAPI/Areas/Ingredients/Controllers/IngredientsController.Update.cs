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
        [HttpPut("{ingredientId}")]
        [Authorize(StaticRoles.Admin)]
        [ProducesResponseType(typeof(IngredientDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute]Guid ingredientId, [FromBody]IngredientDTO ingredient)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var dbIngredient = await _rw.Ingredient.GetIngredientByIdAsync(ingredientId);
                var ingredientMap = _mapper.Map<IngredientDTO, Entities.Ingredient>(ingredient);
                await _rw.Ingredient.UpdateIngredientAsync(ingredientMap, dbIngredient);
                ingredient = _mapper.Map<Entities.Ingredient, IngredientDTO>(await _rw.Ingredient.GetIngredientByIdAsync(ingredientId));
                return Ok(ingredient);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
