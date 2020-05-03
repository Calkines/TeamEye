using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamEye.Crosscutting.Utils;
using TeamEye.Services.Interfaces;

namespace TeamEye.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeitorController : ControllerBase
    {
        private readonly ILogger<LeitorController> _logger;
        private readonly ILeitorDadosCampeonatoService _service;
        public LeitorController(ILogger<LeitorController> logger, ILeitorDadosCampeonatoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            try
            {
                _logger.LogInformation($"Nova importação de arquivo. Nome arquivo: \'{file.FileName}\'. Tamanho: \'{file.Length}\' bytes");
                using (var stream = file.OpenReadStream())
                {
                    _service.ImportarDados(stream);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(LogHelpers.FormatarMensagemErro(ex));
                return BadRequest();
            }
            
        }
    }
}
