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
    public class TimeService : ITimeService
    {
        private readonly ITimeRepository _repo;
        private readonly IMapper _mapper;
        private readonly IDetalheCampeonatoService _detalheCampService;
        public TimeService(ITimeRepository repo, IMapper mapper, IDetalheCampeonatoService _detalheCampSerivce)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IList<TimeViewModel> RecuperarDadosTime()
        {
            return _mapper.Map<List<TimeViewModel>>(_repo.SelecionarTodos());
        }

        public RetornoPorTimeViewModel RecuperarDadosTime(int id)
        {
            var baseDados = _detalheCampService.SelecionarDetalheCampeonatoPorTime(id);
            var resultado = new RetornoPorTimeViewModel()
            {
                TotalDerrotas = baseDados.Sum(x => x.Derrotas),
                TotalEmpates = baseDados.Sum(x => x.Empates),
                TotalGolsContra = baseDados.Sum(x => x.GolsContra),
                TotalGolsPro = baseDados.Sum(x => x.GolsPro),
                TotalJogos = baseDados.Sum(x => x.Jogos),
                NomeTimeNormalizado = baseDados.FirstOrDefault()?.NomeTimeNormalizado,
                Posicao = (int)baseDados.Average(x => x.Posicao),
                QuantidadeCampeonatosDisputados = baseDados.Count,
                TotalPontos = baseDados.Sum(x => x.Pontos),
                TotalVitorias = baseDados.Sum(x => x.Vitorias)
            };
            return resultado;
        }


    }
}
