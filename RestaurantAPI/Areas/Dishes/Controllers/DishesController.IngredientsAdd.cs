using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Areas.Dishes.Controllers
{
    public partial class DishesController
    {
        [HttpPost("{disheId}/ingredients/{ingredientId}")]
        [Authorize(StaticRoles.Business)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> AddIngredient(Guid disheId, Guid ingredientId)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var dish = await _rw.Dish.GetDishByIdAsync(disheId);
                if (!await _rw.Company.CheckManagerAuthorizationAsync(dish.CompanyId, new Guid(User.Identity.Name)))
                    return Forbid();

                await _dishService.AddIngredient(disheId, ingredientId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
