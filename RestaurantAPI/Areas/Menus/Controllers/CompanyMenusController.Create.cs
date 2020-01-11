using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Areas.Menus.Controllers
{
    public partial class CompanyMenusController
    {
        [Authorize(StaticRoles.Business)]
        [ProducesResponseType(typeof(MenuDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]MenuDTO menu)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                if (!await _rw.Company.CheckManagerAuthorizationAsync(menu.CompanyId, new Guid(User.Identity.Name)))
                    return Forbid();

                var menuMap = _mapper.Map<MenuDTO, Entities.Menu>(menu);
                await _rw.Menu.CreateMenuAsync(menuMap);
                menu = _mapper.Map<Entities.Menu, MenuDTO>(menuMap);

                return CreatedAtAction(nameof(GetById), new { menu.Id }, menu);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
