using RestaurantAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace RestaurantAPI.Areas.Companies.Controllers
{
    public partial class CompaniesController
    {
        [HttpPost("{companyId}/calendars/dishes")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> OwnDishCalendarsAdd(Guid companyId, DishCalendarDTO dishCalendarDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                if (!await _rw.Company.CheckManagerAuthorizationAsync(companyId, new Guid(User.Identity.Name)))
                    return Forbid();

                var dish = await _rw.Dish.GetDishByIdAsync(dishCalendarDTO.DishId);

                if(companyId != dish.CompanyId)
                    return BadRequest("O id da empresa é diferente do prato.");

                var dishCalendarMap = _mapper.Map<DishCalendarDTO, Entities.DishCalendar>(dishCalendarDTO);
                dishCalendarMap.Date = new DateTime(dishCalendarDTO.StartTime.Year, dishCalendarDTO.StartTime.Month, dishCalendarDTO.StartTime.Day);
                dishCalendarMap.CompanyId = companyId;

                await _companyService.AddDishCalendar(dishCalendarMap);
                dishCalendarDTO = _mapper.Map<Entities.DishCalendar, DishCalendarDTO>(dishCalendarMap);
                return Ok(dishCalendarDTO);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
