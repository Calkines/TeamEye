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
        private readonly ICampeonatoRepository _campRepo;
        private readonly ITimeRepository _timeRepo;
        private readonly IDetalheCampeonatoRepository _detalheRepo;
        private readonly IMapper _mapper;
        private readonly IDetalheCampeonatoService _detalheCampService;
        private readonly ITimeService _timeService;
        public DadosComplementaresService(IEstadoRepository estadoRepo, IMapper mapper, IDetalheCampeonatoService detalheCampSerivce, ITimeService timeService,
                                          IDetalheCampeonatoRepository detalheRepo, ITimeRepository timeRepo, ICampeonatoRepository campRepo)
        {
            _estadoRepo = estadoRepo;
            _mapper = mapper;
            _detalheCampService = detalheCampSerivce;
            _timeService = timeService;
            _detalheRepo = detalheRepo;
            _timeRepo = timeRepo;
            _campRepo = campRepo;
        }

        public DadosComplementaresViewModel RecuperarDadosComplementares()
        {
            var times = _timeRepo.EntidadePesquisavel().ToList();
            var campeonatos = _campRepo.EntidadePesquisavel().ToList();
            var detalhesCampeonato = _detalheRepo.EntidadePesquisavel().ToList();

            var result = new DadosComplementaresViewModel();

            var melhorGolsContra = RecuperarMelhorMediaGolsContra();
            result.MelhorMediaDeGolsContra = new KeyValuePair<string, int>(times.Where(x => x.Id == melhorGolsContra.Key).FirstOrDefault().NomeNormalizado,
                                                                                            melhorGolsContra.Value);

            var melhorGolsPro = RecuperarMelhorMediaGolsPro();
            result.MelhorMediaDeGolsPro= new KeyValuePair<string, int>(times.Where(x => x.Id == melhorGolsPro.Key).FirstOrDefault().NomeNormalizado, 
                                                                                            melhorGolsPro.Value);

            var timeComMaisVitorias = RecuperarTimeComMaisVitorias();
            result.MaiorNumeroVitorias = new KeyValuePair<string, int>(times.Where(x => x.Id == timeComMaisVitorias.Key).FirstOrDefault().NomeNormalizado, 
                                                                                            timeComMaisVitorias.Value);

            var timeComMenosVitorias = RecuperarTimeComMenosVitorias();
            result.MenorNumeroVitorias = new KeyValuePair<string, int>(times.Where(x => x.Id == timeComMenosVitorias.Key).FirstOrDefault().NomeNormalizado,
                                                                                            timeComMenosVitorias.Value);
            var melhorMediaVitoriasPorCampeonato = RecuperarMelhorMediaVitoriaPorCampeonato(detalhesCampeonato);
            foreach (var camp in melhorMediaVitoriasPorCampeonato)
            {
                result.MelhorMediaVitoriasPorCampeonato.Add(new ResultadoPorCampeonatoViewModel() {
                    Ano = campeonatos.Where(x => x.Id == camp.Item1).FirstOrDefault().Ano,
                    NomeTime = times.Where(x => x.Id == camp.Item2).FirstOrDefault().NomeNormalizado,
                    Valor = camp.Item3
                });
            }

            var menorMediaVitoriasPorCampeonato = RecuperarMenorMediaVitoriaPorCampeonato(detalhesCampeonato);
            foreach (var camp in menorMediaVitoriasPorCampeonato)
            {
                result.MenorMediaVitoriasPorCampeonato.Add(new ResultadoPorCampeonatoViewModel()
                {
                    Ano = campeonatos.Where(x => x.Id == camp.Item1).FirstOrDefault().Ano,
                    NomeTime = times.Where(x => x.Id == camp.Item2).FirstOrDefault().NomeNormalizado,
                    Valor = camp.Item3
                });
            }

            return result;
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

        private KeyValuePair<int, int> RecuperarMelhorMediaGolsPro()
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
            return new KeyValuePair<int, int>(dadosBanco.FirstOrDefault().Time, (int)dadosBanco.FirstOrDefault().MediaGols);
        }
        private KeyValuePair<int, int> RecuperarMelhorMediaGolsContra()
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
            return new KeyValuePair<int, int>(dadosBanco.FirstOrDefault().Time, (int)dadosBanco.FirstOrDefault().MediaGols);
        }
        private KeyValuePair<int, int> RecuperarTimeComMaisVitorias()
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
            return new KeyValuePair<int, int>(dadosBanco.FirstOrDefault().Time, (int)dadosBanco.FirstOrDefault().Vitorias);
        }
        private KeyValuePair<int, int> RecuperarTimeComMenosVitorias()
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
            return new KeyValuePair<int, int>(dadosBanco.FirstOrDefault().Time, (int)dadosBanco.FirstOrDefault().Vitorias);
        }
        private List<Tuple<int, int, int>> RecuperarMelhorMediaVitoriaPorCampeonato(List<DetalheCampeonato> detalhesCampeonato)
        {
            var result = from detalhe in detalhesCampeonato
                         group detalhe by detalhe.CampeonatoId into campGroup
                         select campGroup;
            var dadosBanco = result.ToList();
            var lstResultado = new List<Tuple<int, int, int>>();
            foreach (var camp in dadosBanco)
            {
                lstResultado.Add(new Tuple<int, int, int>(camp.Where(x => x.Vitorias == camp.Max(x => x.Vitorias)).FirstOrDefault().CampeonatoId,
                                                          camp.Where(x => x.Vitorias == camp.Max(x => x.Vitorias)).FirstOrDefault().TimeId,
                                                          (int)camp.Where(x => x.Vitorias == camp.Max(x => x.Vitorias)).FirstOrDefault().Vitorias
                                                          )
                                );
            }
            return lstResultado;
        }
        private List<Tuple<int, int, int>> RecuperarMenorMediaVitoriaPorCampeonato(List<DetalheCampeonato> detalhesCampeonato)
        {
            var result = from detalhe in detalhesCampeonato
                         group detalhe by detalhe.CampeonatoId into campGroup                         
                         select campGroup;
            var dadosBanco = result.ToList();
            var lstResultado = new List<Tuple<int, int, int>>();
            foreach (var camp in dadosBanco)
            {
                lstResultado.Add(new Tuple<int, int, int>(camp.Where(x => x.Vitorias == camp.Min(x => x.Vitorias)).FirstOrDefault().CampeonatoId,
                                                          camp.Where(x => x.Vitorias == camp.Min(x => x.Vitorias)).FirstOrDefault().TimeId,
                                                          (int)camp.Where(x => x.Vitorias == camp.Min(x => x.Vitorias)).FirstOrDefault().Vitorias
                                                          )
                                );
            }
            return lstResultado;
        }
        
    }
}
