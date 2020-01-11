using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Areas.Companies.Controllers
{
    public partial class CompaniesController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CompanyDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            try
            {
                var companies = await _rw.Company.GetCompaniesAsync();
                var companiesMap = _mapper.Map<IEnumerable<Entities.Company>, IEnumerable<CompanyDTO>>(companies);
                return Ok(companiesMap);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
