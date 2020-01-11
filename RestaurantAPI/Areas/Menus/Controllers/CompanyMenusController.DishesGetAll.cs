using RestaurantAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Areas.Menus.Controllers
{
    public partial class CompanyMenusController
    {
        [HttpGet("{menuId}/Dishes")]
        [ProducesResponseType(typeof(IEnumerable<DishDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDishes(Guid menuId, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<Entities.Dish>, IEnumerable<DishDTO>>
                    (await _rw.Dish.GetDishesByMenuAsync(menuId)));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
