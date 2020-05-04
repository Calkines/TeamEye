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
            try
            {
                _logger.LogInformation("Inicio da geração de dados complementares");
                return Ok(_service.RecuperarDadosComplementares());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Falha na geração de dados complementares. Message: {ex.Message}");
                return BadRequest();
            }
        }
    }
}
