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
        [InlineData("Atlético MG", "ATLETICO MG")]
        public void Dado_NomesDesnormalizados_Quando_ReliazaCriacaoDoObjetoTime_Entao_NomeNormalizadoDeveCorresponderAoEsperado(string nomeDesnormalizado, string normalizado)
        {
            //Arrange
            var estado = new Estado("RS");
            //Act
            var time = new Time(nomeDesnormalizado, estado);
            //Assert
            Assert.Equal(normalizado,time.NomeNormalizado);
            
        }
    }
}
