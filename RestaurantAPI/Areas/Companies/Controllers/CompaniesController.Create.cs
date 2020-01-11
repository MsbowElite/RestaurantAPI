using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RestaurantAPI.Areas.Companies.Controllers
{
    public partial class CompaniesController
    {
        [Authorize(Roles = StaticRoles.Business)]
        [ProducesResponseType(typeof(CompanyDTO), StatusCodes.Status201Created)]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]CompanyDTO company)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var companyMap = _mapper.Map<CompanyDTO, Entities.Company>(company);
                await _rw.Company.CreateCompanyAsync(companyMap, new Guid(User.Identity.Name));
                company = _mapper.Map<Entities.Company, CompanyDTO>(companyMap);
                return CreatedAtAction(nameof(GetById), new { company.Id }, company);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
