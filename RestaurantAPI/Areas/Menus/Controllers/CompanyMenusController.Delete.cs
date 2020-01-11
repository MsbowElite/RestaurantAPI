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
        [HttpDelete("{id}")]
        [Authorize(StaticRoles.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var companyMenu = await _rw.CompanyMenus.GetCompanyMenuByIdAsync(id);

                if (companyMenu == null)
                {
                    return NotFound();
                }

                await _rw.CompanyMenus.DeleteCompanyMenuAsync(companyMenu);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
