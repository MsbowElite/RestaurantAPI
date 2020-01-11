using AutoMapper;
using RestaurantAPI.Entities.Repository.Interfaces;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Areas.Menus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(StaticRoles.Customer)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public partial class CompanyMenusController : ControllerBase
    {
        private readonly IRepositoryWrapper _rw;
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CompanyMenusController(IRepositoryWrapper rw, IMenuService menuService, IMapper mapper, ILogger<CompanyMenusController> logger)
        {
            _rw = rw;
            _menuService = menuService;
            _mapper = mapper;
            _logger = logger;
        }
    }
}
