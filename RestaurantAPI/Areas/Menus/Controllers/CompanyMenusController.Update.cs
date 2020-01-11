using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
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
        [HttpPut("{menuId}")]
        [Authorize(StaticRoles.Admin)]
        [ProducesResponseType(typeof(MenuDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute]Guid menuId, [FromBody]MenuDTO menu)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var dbMenu = await _rw.Menu.GetMenuByIdAsync(menuId);
                var menuMap = _mapper.Map<MenuDTO, Entities.Menu>(menu);
                dbMenu.Name = menuMap.Name;
                await _rw.Menu.UpdateMenuAsync(dbMenu);
                menu = _mapper.Map<Entities.Menu, MenuDTO>(await _rw.Menu.GetMenuByIdAsync(menuId));
                return Ok(menu);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
