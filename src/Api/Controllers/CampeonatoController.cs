using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TeamEye.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampeonatoController : ControllerBase
    {
        private readonly ILogger<CampeonatoController> _logger;

        public CampeonatoController(ILogger<CampeonatoController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<DadosCampeonatoViewModel> Get()
        //{
        //}
    }
}
