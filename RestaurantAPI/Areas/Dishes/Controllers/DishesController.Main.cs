using AutoMapper;
using RestaurantAPI.Entities.Repository.Interfaces;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Areas.Dishes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(StaticRoles.Customer)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public partial class DishesController : ControllerBase
    {
        private readonly IRepositoryWrapper _rw;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IDishService _dishService;

        public DishesController(IRepositoryWrapper rw, IDishService dishService, IMapper mapper, ILogger<DishesController> logger)
        {
            _rw = rw;
            _mapper = mapper;
            _logger = logger;
            _dishService = dishService;
        }
    }
}
