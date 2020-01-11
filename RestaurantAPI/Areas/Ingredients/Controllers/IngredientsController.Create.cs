using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Areas.Ingredients.Controllers
{
    public partial class IngredientsController
    {
        [Authorize(StaticRoles.Business)]
        [ProducesResponseType(typeof(IngredientDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]IngredientDTO ingredient)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var ingredientMap = _mapper.Map<IngredientDTO, Entities.Ingredient>(ingredient);
                await _rw.Ingredient.CreateIngredientAsync(ingredientMap, new Guid(User.Identity.Name));
                ingredient = _mapper.Map<Entities.Ingredient, IngredientDTO>(ingredientMap);
                return CreatedAtAction(nameof(GetById), new { ingredient.Id }, ingredient);
            }
            catch (SqlException ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                if(ex.InnerException != null)
                {
                    ex.InnerException.Message.Contains("Duplicate");
                    return StatusCode(409);
                }
                _logger.LogWarning(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
