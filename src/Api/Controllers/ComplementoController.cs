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
    public class ComplementoController : ControllerBase
    {
        private readonly ILogger<ComplementoController> _logger;
        private readonly IDadosComplementaresService _service;

        public ComplementoController(ILogger<ComplementoController> logger, IDadosComplementaresService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //return Ok(_service.RecuperarDadosTime());
            return Ok(_service.RecuperarDadosComplementares());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //return Ok(_service.RecuperarDadosTime(id));
            return Ok();
        }
    }
}
