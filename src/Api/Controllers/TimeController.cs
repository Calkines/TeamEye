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
            try
            {
                _logger.LogInformation("Início da requisição de dados por Time de forma geral.");
                return Ok(_service.RecuperarDadosTime());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Falha na execução da requisição de times. Message: {ex.Message}");
                return BadRequest();
            }            
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _logger.LogInformation("Início da requisição de dados por Times de forma específica.");
                return Ok(_service.RecuperarDadosTime(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Falha na execução da requisição de times. Message: {ex.Message}");
                return BadRequest();
            }
            
        }
    }
}
