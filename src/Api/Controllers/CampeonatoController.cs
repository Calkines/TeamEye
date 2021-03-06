﻿using System;
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
    public class CampeonatoController : ControllerBase
    {
        private readonly ILogger<CampeonatoController> _logger;
        private readonly ICampeonatoService _service;

        public CampeonatoController(ILogger<CampeonatoController> logger, ICampeonatoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.RecuperarDadosCampeonato());
        }
        [HttpGet("{ano}")]
        public IActionResult Get(int ano)
        {
            return Ok(_service.RecuperarDadosCampeonato(ano));
        }
    }
}
