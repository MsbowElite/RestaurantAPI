using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Areas.Dishes.Controllers
{
    public partial class DishesController
    {
        [Authorize(StaticRoles.Business)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpDelete("{disheId}/ingredients/{ingredientId}")]
        public async Task<IActionResult> RemoveIngredient(Guid disheId, Guid ingredientId)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var dish = await _rw.Dish.GetDishByIdAsync(disheId);
                if (!await _rw.Company.CheckManagerAuthorizationAsync(dish.CompanyId, new Guid(User.Identity.Name)))
                    return Forbid();

                await _dishService.RemoveIngredient(disheId, ingredientId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
