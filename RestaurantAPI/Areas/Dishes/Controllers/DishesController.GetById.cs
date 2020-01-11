using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Areas.Dishes.Controllers
{
    public partial class DishesController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DishDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var dishe = await _rw.Dish.GetDishByIdAsync(id);

                if (dishe == null)
                {
                    return NotFound();
                }

                var disheMap = _mapper.Map<Entities.Dish, DishDTO>(dishe);
                return Ok(disheMap);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
