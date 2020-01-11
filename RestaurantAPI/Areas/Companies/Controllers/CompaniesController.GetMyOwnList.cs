using RestaurantAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace RestaurantAPI.Areas.Companies.Controllers
{
    public partial class CompaniesController
    {
        [HttpGet("GetMyOwnList")]
        [Authorize("Business")]
        [ProducesResponseType(typeof(IEnumerable<CompanyDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMyOwnList([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            try
            {
                var companies = await _rw.Company.GetMyOwnCompaniesAsync(new Guid(User.Identity.Name));
                if (companies == null)
                {
                    return NotFound();
                }
                var companiesMap = _mapper.Map<IEnumerable<Entities.Company>, IEnumerable<CompanyDTO>>(companies);
                return Ok(companiesMap);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message); 
                return StatusCode(500);
            }
        }
    }
}
