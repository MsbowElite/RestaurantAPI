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
        [Authorize(StaticRoles.Business)]
        [ProducesResponseType(typeof(MenuDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost("{menuId}/dishe/{disheId}")]
        public async Task<IActionResult> AddDishe(Guid menuId, Guid disheId)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                await _menuService.AddDishe(menuId, disheId);
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
