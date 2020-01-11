using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RestaurantAPI.Entities.Repository.Interfaces;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Areas.Ingredients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(StaticRoles.Customer)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public partial class IngredientsController : ControllerBase
    {
        private readonly IRepositoryWrapper _rw;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public IngredientsController(IRepositoryWrapper rw, IMapper mapper, ILogger<IngredientsController> logger)
        {
            _rw = rw;
            _mapper = mapper;
            _logger = logger;
        }
    }
}
