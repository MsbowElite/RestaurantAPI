using RestaurantAPI.Models;
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
        [HttpGet("{companyId}/calendars/date/{dateTicks}/dishes")]
        [ProducesResponseType(typeof(IEnumerable<DishCalendarDateDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DishCalendarsOwnDate(Guid companyId, long dateTicks)
        {
            try
            {
                var date = new DateTime(dateTicks);
                var dishCalendars = await _rw.DishCalendar.GetDishCalendarsByCompanyPerDateAsync(companyId, date);
                return Ok(_mapper.Map<IEnumerable<Entities.DishCalendar>, IEnumerable<DishCalendarDateDTO>>(dishCalendars));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
