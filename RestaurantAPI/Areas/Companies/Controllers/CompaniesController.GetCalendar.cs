using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace RestaurantAPI.Areas.Companies.Controllers
{
    public partial class CompaniesController
    {
        [HttpGet("GetCalendar/{companyId}")]
        public async Task<IActionResult> GetCalendar(Guid companyId)
        {
            try
            {
                var company = await _rw.Company.GetCompanyByIdAsync(companyId);
                if (company == null)
                {
                    return NotFound();
                }
                switch (company.MenuOption)
                {
                    case 0:

                        break;
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
