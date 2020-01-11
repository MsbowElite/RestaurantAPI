using AutoMapper;
using RestaurantAPI.Entities.Repository.Interfaces;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace RestaurantAPI.Areas.Companies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(StaticRoles.Customer)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public partial class CompaniesController : ControllerBase
    {
        private readonly IRepositoryWrapper _rw;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICompanyService _companyService;

        public CompaniesController(IRepositoryWrapper rw, ICompanyService companyService, IMapper mapper, ILogger<CompaniesController> logger)
        {
            _rw = rw;
            _mapper = mapper;
            _logger = logger;
            _companyService = companyService;
        }
    }
}
