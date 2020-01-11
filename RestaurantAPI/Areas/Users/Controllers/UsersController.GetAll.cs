using System;
using System.Threading.Tasks;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Areas.Users.Controllers
{
    public partial class UsersController
    {
        [HttpGet]
        [Authorize(StaticRoles.Admin)]
        [ProducesResponseType(typeof(UserAuthModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            try
            {
                var users = await _rw.User.GetUsersAsync();
                var usersMap = _mapper.Map<IEnumerable<Entities.User>, IEnumerable<Models.UserModel>>(users);
                return Ok(usersMap);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}