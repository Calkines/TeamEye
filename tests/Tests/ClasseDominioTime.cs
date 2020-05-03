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

namespace TeamEye.Core
{
    public class ClasseDominioTime
    {
        private readonly IMapper _mapper;
        public ClasseDominioTime()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(AutoMapperProfile));
            }).CreateMapper();
        }

        [Theory]
        [InlineData("Grêmio","GREMIO")]
        [InlineData("Avaí","AVAI")]
        [InlineData("São Paulo", "SAO PAULO")]
        public void Dado_NomeDesnormalizadoComAcentos_Quando_ReliazaCriacaoDoObjetoTime_Entao_NomeNormalizadoDeveCorresponderAoEsperadoSemAcentos(string nomeDesnormalizado, string normalizado)
        {
            //Arrange
            var estado = new Estado("RS");
            //Act
            var time = new Time(nomeDesnormalizado, estado);
            //Assert
            Assert.Equal(normalizado,time.NomeNormalizado);
            
        }

        [Theory]
        [InlineData("Atletico Pr", "ATLETICO PARANAENSE")]
        public void Dado_NomeDesnormalizadoComSigla_Quando_ReliazaCriacaoDoObjetoTime_Entao_NomeNormalizadoDeveCorresponderAoEsperadoComAdjetivoPatrio(string nomeDesnormalizado, string normalizado)
        {
            //Arrange
            var estado = new Estado("PR");
            //Act
            var time = new Time(nomeDesnormalizado, estado);
            //Assert
            Assert.Equal(normalizado, time.NomeNormalizado);

        }

        [Theory]
        [InlineData("Atlético Mg", "ATLETICO MINEIRO")]
        [InlineData("Atlético Pr","ATLETICO PARANAENSE")]
        public void Dado_NomeDesnormalizadoComSiglaEAcento_Quando_ReliazaCriacaoDoObjetoTime_Entao_NomeNormalizadoDeveCorresponderAoEsperadoComAdjetivoPatrioESemAcento(string nomeDesnormalizado, string normalizado)
        {
            //Arrange
            var estado = new Estado("PR");
            //Act
            var time = new Time(nomeDesnormalizado, estado);
            //Assert
            Assert.Equal(normalizado, time.NomeNormalizado);

        }

        [Theory]
        [InlineData("CSA", "CENTRO SPORTIVO ALAGOANO")]
        public void Dado_NomeDesnormalizadoComGrafiaErrada_Quando_ReliazaCriacaoDoObjetoTime_Entao_NomeNormalizadoDeveCorresponderAoEsperadoComCorretaGrafia(string nomeDesnormalizado, string normalizado)
        {
            //Arrange
            var estado = new Estado("AL");
            //Act
            var time = new Time(nomeDesnormalizado, estado);
            //Assert
            Assert.Equal(normalizado, time.NomeNormalizado);

        }
    }
}
