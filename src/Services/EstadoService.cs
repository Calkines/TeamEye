using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamEye.Core.Interfaces;
using TeamEye.Crosscutting.ViewModel;
using TeamEye.Services.Interfaces;

namespace TeamEye.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _repo;
        private readonly IMapper _mapper;
        private readonly IDetalheCampeonatoService _detalheCampService;
        private readonly ITimeService _timeService;
        public EstadoService(IEstadoRepository repo, IMapper mapper, IDetalheCampeonatoService detalheCampSerivce, ITimeService timeService)
        {
            _repo = repo;
            _mapper = mapper;
            _detalheCampService = detalheCampSerivce;
            _timeService = timeService;
        }
        public IList<EstadoViewModel> RecuperarDadosTime()
        {
            return _mapper.Map<List<EstadoViewModel>>(_repo.SelecionarTodos());
        }

        public RetornoPorEstadoViewModel RecuperarDadosTime(int estadoId)
        {

            var listaIds = _timeService.RecuperarDadosTimePorEstadoId(estadoId).ToList().Select(x => x.Id).ToList();
            var baseDados = _detalheCampService.SelecionarDetalheCampeonatoPorTime(listaIds);
            var resultado = new RetornoPorEstadoViewModel()
            {
                TotalDerrotas = baseDados.Sum(x => x.Derrotas),
                TotalEmpates = baseDados.Sum(x => x.Empates),
                TotalGolsContra = baseDados.Sum(x => x.GolsContra),
                TotalGolsPro = baseDados.Sum(x => x.GolsPro),
                TotalJogos = baseDados.Sum(x => x.Jogos),
                SiglaEstado = baseDados.FirstOrDefault()?.SiglaEstado,
                Posicao = (int)baseDados.Average(x => x.Posicao),
                QuantidadeCampeonatosDisputados = baseDados.Count,
                TotalPontos = baseDados.Sum(x => x.Pontos),
                TotalVitorias = baseDados.Sum(x => x.Vitorias)
            };
            return resultado;
        }


    }
}
