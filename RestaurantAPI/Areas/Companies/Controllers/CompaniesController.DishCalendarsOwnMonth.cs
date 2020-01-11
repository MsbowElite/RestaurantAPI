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
        [HttpGet("{companyId}/calendars/month/{month}/year/{year}/dishes")]
        [ProducesResponseType(typeof(IEnumerable<DishCalendarDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DishCalendarsOwnMonth(Guid companyId, byte month, int year)
        {
            try
            {

                var dishCalendars = await _rw.DishCalendar.GetDishCalendarsByCompanyPerMonthAsync(companyId, month, year);
                return Ok(_mapper.Map<IEnumerable<Entities.DishCalendar>, IEnumerable<DishCalendarDTO>>(dishCalendars));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
