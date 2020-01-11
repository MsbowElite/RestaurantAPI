using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Areas.Companies.Controllers
{
    public partial class CompaniesController
    {
        [Authorize(StaticRoles.Business)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpDelete("{companyId}/calendars/date/{dateTicks}/dishes/{dishId}")]
        public async Task<IActionResult> RemoveIngredient(Guid companyId, long dateTicks, Guid dishId)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                if (!await _rw.Company.CheckManagerAuthorizationAsync(companyId, new Guid(User.Identity.Name)))
                    return Forbid();

                var dish = await _rw.Dish.GetDishByIdAsync(dishId);

                if (companyId != dish.CompanyId)
                    return BadRequest("O id da empresa é diferente do prato.");

                var date = new DateTime(dateTicks).Date;
                Entities.DishCalendar dishCalendarMap = new Entities.DishCalendar()
                {
                    CompanyId = companyId,
                    DishId = dishId,
                    Date = date
                };

                await _companyService.RemoveDishCalendar(dishCalendarMap);
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
