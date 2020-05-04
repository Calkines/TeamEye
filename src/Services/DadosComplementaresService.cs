using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamEye.Core.Entities;
using TeamEye.Core.Interfaces;
using TeamEye.Crosscutting.ViewModel;
using TeamEye.Services.Interfaces;

namespace TeamEye.Services
{
    public class DadosComplementaresService : IDadosComplementaresService
    {
        private readonly IEstadoRepository _estadoRepo;
        private readonly ITimeRepository _timeRepo;
        private readonly IDetalheCampeonatoRepository _detalheRepo;
        private readonly IMapper _mapper;
        private readonly IDetalheCampeonatoService _detalheCampService;
        private readonly ITimeService _timeService;
        public DadosComplementaresService(IEstadoRepository estadoRepo, IMapper mapper, IDetalheCampeonatoService detalheCampSerivce, ITimeService timeService,
                                          IDetalheCampeonatoRepository detalheRepo, ITimeRepository timeRepo)
        {
            _estadoRepo = estadoRepo;
            _mapper = mapper;
            _detalheCampService = detalheCampSerivce;
            _timeService = timeService;
            _detalheRepo = detalheRepo;
            _timeRepo = timeRepo;
        }

        public DadosComplementaresViewModel RecuperarDadosComplementares()
        {
            var times = _timeRepo.EntidadePesquisavel().ToList();
            var result = new DadosComplementaresViewModel();

            var melhorGolsContra = RecuperarMelhorMediaGolsContra();
            result.MelhorMediaDeGolsContra = new KeyValuePair<string, int>(times.Where(x => x.Id == melhorGolsContra.Keys.FirstOrDefault()).FirstOrDefault().NomeNormalizado,
                                                                                            melhorGolsContra.Values.FirstOrDefault());

            var melhorGolsPro = RecuperarMelhorMediaGolsPro();
            result.MelhorMediaDeGolsPro= new KeyValuePair<string, int>(times.Where(x => x.Id == melhorGolsPro.Keys.FirstOrDefault()).FirstOrDefault().NomeNormalizado, 
                                                                                            melhorGolsPro.Values.FirstOrDefault());

            var timeComMaisVitorias = RecuperarTimeComMaisVitorias();
            result.MaiorNumeroVitorias = new KeyValuePair<string, int>(times.Where(x => x.Id == timeComMaisVitorias.Keys.FirstOrDefault()).FirstOrDefault().NomeNormalizado, 
                                                                                            timeComMaisVitorias.Values.FirstOrDefault());

            var timeComMenosVitorias = RecuperarTimeComMenosVitorias();
            result.MenorNumeroVitorias = new KeyValuePair<string, int>(times.Where(x => x.Id == timeComMenosVitorias.Keys.FirstOrDefault()).FirstOrDefault().NomeNormalizado,
                                                                                            timeComMenosVitorias.Values.FirstOrDefault());



            throw new NotImplementedException();
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

        private Dictionary<int, int> RecuperarMelhorMediaGolsPro()
        {
            var result = from detalhe in _detalheRepo.EntidadePesquisavel()
                         group detalhe by detalhe.TimeId into timeGroup
                         select new
                         {
                             Time = timeGroup.Key,
                             MediaGols = timeGroup.Average(x => x.GolsPro)
                         } into res
                         orderby res.MediaGols descending
                         select res;
            var dadosBanco = result.ToList();
            return new Dictionary<int, int>() { { dadosBanco.FirstOrDefault().Time, (int)dadosBanco.FirstOrDefault().MediaGols } };
        }
        private Dictionary<int,int> RecuperarMelhorMediaGolsContra()
        {
            var result = from detalhe in _detalheRepo.EntidadePesquisavel()
                         group detalhe by detalhe.TimeId into timeGroup
                         select new
                         {
                             Time = timeGroup.Key,
                             MediaGols = timeGroup.Average(x => x.GolsContra)
                         } into res
                         orderby res.MediaGols
                         select res;
            var dadosBanco = result.ToList();
            return new Dictionary<int, int>() { { dadosBanco.FirstOrDefault().Time, (int)dadosBanco.FirstOrDefault().MediaGols } };
        }
        private Dictionary<int, int> RecuperarTimeComMaisVitorias()
        {
            var result = from detalhe in _detalheRepo.EntidadePesquisavel()
                         group detalhe by detalhe.TimeId into timeGroup
                         select new
                         {
                             Time = timeGroup.Key,
                             Vitorias = timeGroup.Max(x => x.Vitorias)
                         } into res
                         orderby res.Vitorias descending
                         select res;
            var dadosBanco = result.ToList();
            return new Dictionary<int, int>() { { dadosBanco.FirstOrDefault().Time, (int)dadosBanco.FirstOrDefault().Vitorias } };
        }
        private Dictionary<int, int> RecuperarTimeComMenosVitorias()
        {
            var result = from detalhe in _detalheRepo.EntidadePesquisavel()
                         group detalhe by detalhe.TimeId into timeGroup
                         select new
                         {
                             Time = timeGroup.Key,
                             Vitorias = timeGroup.Max(x => x.Vitorias)
                         } into res
                         orderby res.Vitorias ascending
                         select res;
            var dadosBanco = result.ToList();
            return new Dictionary<int, int>() { { dadosBanco.FirstOrDefault().Time, (int)dadosBanco.FirstOrDefault().Vitorias } };
        }
        private List<KeyValuePair<string, int>> RecuperarMediaVitoriaPorCampeonato()
        {
            var result = from detalhe in _detalheRepo.EntidadePesquisavel()
                         group detalhe by detalhe.CampeonatoId into campGroup
                         select new
                         {
                             Campeonato = campGroup.Key,
                             Time = campGroup.GroupBy(x => x.TimeId)                             
                         } into res
                         orderby res.Time ascending
                         select res;
            var dadosBanco = result.ToList();

            foreach (var campeonato in dadosBanco)
            {

            }
            return new Dictionary<int, int>() { { dadosBanco.FirstOrDefault().Time, (int)dadosBanco.FirstOrDefault().Vitorias } };
        }
    }
}
