using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace RestaurantAPI.Areas.Users.Controllers
{

    public partial class UsersController
    {
        [HttpPost("Authenticate")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(TokenModel), StatusCodes.Status200OK)]
        public IActionResult Authenticate()
        {
            try
            {
                return Ok(_userService.Authentication());
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
