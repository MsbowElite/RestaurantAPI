using RestaurantAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RestaurantAPI.Areas.Users.Controllers
{
    public partial class UsersController
    {
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status201Created)]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserModel user)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var userMap = _mapper.Map<UserModel, Entities.User>(user);
                await _userService.Register(userMap);
                return CreatedAtAction(nameof(Login), user);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    _logger.LogDebug(ex.InnerException.Message);
                }
                else
                {
                    _logger.LogDebug(ex.Message);
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
