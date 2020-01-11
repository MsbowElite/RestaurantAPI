using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Areas.Menus.Controllers
{
    public partial class CompanyMenusController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MenuDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            try
            {
                var menus = await _rw.Menu.GetMenusAsync();
                var menusMap = _mapper.Map<IEnumerable<Entities.Menu>, IEnumerable<MenuDTO>>(menus);
                return Ok(menusMap);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
