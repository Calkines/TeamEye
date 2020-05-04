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
    public class EstadoController : ControllerBase
    {
        private readonly ILogger<EstadoController> _logger;
        private readonly IEstadoService _service;

        public EstadoController(ILogger<EstadoController> logger, IEstadoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("Início da requisição de dados por Estado de forma geral.");
                return Ok(_service.RecuperarDadosTime());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Falha na execução da requisição de Estados. Message: {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _logger.LogInformation("Início da requisição de dados por Estado de forma específica.");
                return Ok(_service.RecuperarDadosTime(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Falha na execução da requisição de Estados. Message: {ex.Message}");
                return BadRequest();
            }
            
            
        }
    }
}
