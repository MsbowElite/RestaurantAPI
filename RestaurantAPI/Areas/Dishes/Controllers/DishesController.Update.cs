using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Areas.Dishes.Controllers
{
    public partial class DishesController
    {
        [HttpPut("{id}")]
        [Authorize(StaticRoles.Business)]
        [ProducesResponseType(typeof(DishDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Update(Guid id, [FromBody]DishDTO dishe)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                if (await _rw.Company.CheckManagerAuthorizationAsync(dishe.CompanyId, new Guid(User.Identity.Name)))
                    return Forbid();

                var entity = await _rw.Dish.GetDishByIdAsync(id);
                entity.Name = dishe.Name;
                await _rw.Dish.UpdateDishAsync(entity);

                dishe = _mapper.Map<Entities.Dish, DishDTO>(entity);
                return Ok(dishe);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
