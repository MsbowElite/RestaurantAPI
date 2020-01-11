using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace RestaurantAPI.Areas.Dishes.Controllers
{
    public partial class DishesController
    {
        [Authorize(StaticRoles.Business)]
        [ProducesResponseType(typeof(DishDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]DishDTO dishe)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                if (!await _rw.Company.CheckManagerAuthorizationAsync(dishe.CompanyId, new Guid(User.Identity.Name)))
                    return Forbid();

                var disheMap = _mapper.Map<DishDTO, Entities.Dish>(dishe);
                await _rw.Dish.CreateDishAsync(disheMap);
                dishe = _mapper.Map<Entities.Dish, DishDTO>(disheMap);
                return CreatedAtAction(nameof(GetById), new { dishe.Id }, dishe);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
