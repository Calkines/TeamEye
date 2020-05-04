using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeamEye.Crosscutting.ViewModel;
using TeamEye.Services.Interfaces;

namespace TeamEye.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeController : ControllerBase
    {
        private readonly ILogger<TimeController> _logger;
        private readonly ITimeService _service;

        public TimeController(ILogger<TimeController> logger, ITimeService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.RecuperarDadosTime());
            //return Ok(_service.RecuperarDadosCampeonato());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
            //return Ok(_service.RecuperarDadosCampeonato(ano));
        }
    }
}
