using RestaurantAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Areas.Users.Controllers
{
    public partial class UsersController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserAuthModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var user = await _rw.User.GetUserByIdAsync(id);

                if (user == null)
                {
                    return NotFound();
                }
                //TODO MSBOWELITE SETUP RICH UserModel
                if (User.Identity.Name.Equals(user.Id.ToString()))
                {
                    var usersMap = _mapper.Map<Entities.User, UserModel>(user);
                    return Ok(usersMap);
                }
                else
                {
                    var usersMap = _mapper.Map<Entities.User, UserModel>(user);
                    return Ok(usersMap);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}