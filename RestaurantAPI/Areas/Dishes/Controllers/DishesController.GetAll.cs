using RestaurantAPI.Models;
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
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DishDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            try
            {
                var dishes = await _rw.Dish.GetDishesAsync();
                var dishesMap = _mapper.Map<IEnumerable<Entities.Dish>, IEnumerable<DishDTO>>(dishes);
                return Ok(dishesMap);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
