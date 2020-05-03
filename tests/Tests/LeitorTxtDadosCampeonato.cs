using AutoMapper;
using System;
using System.IO;
using System.Linq;
using System.Text;
using TeamEye.Core.Crosscutting.Automapper;
using TeamEye.Core.Entities;
using TeamEye.Crosscutting.ViewModel;
using TeamEye.Infra.Leitores;
using TeamEye.Infra.Leitores.Exceptions;
using Xunit;

namespace TeamEye.Infra
{
    public class LeitorTxtDadosCampeonato
    {
        private readonly IMapper _mapper;
        public LeitorTxtDadosCampeonato()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(AutoMapperProfile));
            }).CreateMapper();
        }
        [Theory]
        [InlineData("01	Corinthians		SP		81	38	24	9	5	71	31	")]
        [InlineData("03	Grêmio			RS		68	38	20	8	10	52	32")]
        [InlineData("05	Internacional	RS		60	38	17	9	12	39	38")]
        public void Dado_UmaLinhaComDezInformacoes_Quando_RealizarLeituraDaLinhaEsperandoDezInformacoes_Entao_UmObjetoRepresentandoOsDetalhesDoCampeonatoDeveSerRetornado(string linha)
        {
            //Arrange            
            var leitor = new Infra.Leitores.LeitorTxtDadosCampeonato(_mapper);
            var campeonato = new Campeonato(2015);

            //Act
            LineDatailViewModel resultado = leitor.InterpretarDetalhesCampeonato(linha);

            //Assert
            Assert.NotNull(resultado);
        }

        [Theory]
        [InlineData("01	Corinthians		SP		81	38	24	9	5	71	")]
        public void Dado_UmaLinhaComNoveInformacoes_Quando_RealizarLeituraDaLinhaEsperandoDezInformacoes_Entao_UmaExcecaoDeLinhaComDadosIncompletosDeveSerLancada(string linha)
        {
            //Arrange            
            var leitor = new Leitores.LeitorTxtDadosCampeonato(_mapper);
            var campeonato = new Campeonato(2015);

            //Assert
            Assert.Throws<DadosIncompletosException>(() =>
            {
                //Act
                LineDatailViewModel resultado = leitor.InterpretarDetalhesCampeonato(linha);
            });
        }

        [Theory]
        [InlineData("Mock//CampeonatoBrasileiro2016.txt")]
        [InlineData("Mock//CampeonatoBrasileiro2017.txt")]
        [InlineData("Mock//CampeonatoBrasileiro2018.txt")]
        [InlineData("Mock//CampeonatoBrasileiro2015.txt")]
        [InlineData("Mock//CampeonatoBrasileiro2019.txt")]
        public void Dado_UmArquivoTextoComFormatoEsperado_QuandoRealizarALeituraDoArquivo_Entao_UmObjetoNaoNuloRepresentandoACampeonatoDeveSerRetornado(string path)
        {
            //Arrange
            var leitor = new Leitores.LeitorTxtDadosCampeonato(_mapper);

            using (var stream = new FileStream(path, FileMode.Open))
            {
                //Act
                var campeonato = leitor.InterpretarDadosCampeonato(stream);
                //Assert
                Assert.IsType<Campeonato>(campeonato);
                Assert.NotNull(campeonato);
            }
        }

        [Theory]
        [InlineData("Mock//CampeonatoBrasileiro2016.txt", 1040)]
        [InlineData("Mock//CampeonatoBrasileiro2017.txt", 1037)]
        [InlineData("Mock//CampeonatoBrasileiro2018.txt",1027)]
        [InlineData("Mock//CampeonatoBrasileiro2015.txt",1049)]
        [InlineData("Mock//CampeonatoBrasileiro2019.txt",1042)]
        public void Dado_ValoresEspecificosDePontosPorCampeonato_QuandoRealizarALeituraDoArquivo_Entao_ASomaDosPontosDeveSerIgualAoEsperado(string path, int somaPontos)
        {
            //Arrange
            var leitor = new Leitores.LeitorTxtDadosCampeonato(_mapper);

            using (var stream = new FileStream(path, FileMode.Open))
            {
                //Act
                var campeonato = leitor.InterpretarDadosCampeonato(stream);
                //Assert
                Assert.IsType<Campeonato>(campeonato);
                Assert.Equal(somaPontos, campeonato.DetalhesCampeonato.Sum(p => p.Pontos));
                Assert.NotNull(campeonato);
            }
        }
    }
}
