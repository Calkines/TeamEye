using System;
using System.Text;
using TeamEye.Core.Entities;
using TeamEye.Infra.Leitores;
using TeamEye.Infra.Leitores.Exceptions;
using Xunit;

namespace TeamEye.Infra
{
    public class LeitorTxtDadosCampeonato
    {
        [Theory]
        [InlineData("01	Corinthians		SP		81	38	24	9	5	71	31	")]
        [InlineData("03	Grêmio			RS		68	38	20	8	10	52	32")]
        [InlineData("05	Internacional	RS		60	38	17	9	12	39	38")]
        public void Dado_UmaLinhaComDezInformacoes_Quando_RealizarLeituraDaLinhaEsperandoDezInformacoes_Entao_UmObjetoRepresentandoOsDetalhesDaRodadaDeveSerRetornado(string linha)
        {
            //Arrange            
            var leitor = new Infra.Leitores.LeitorTxtDadosCampeonato();

            //Act
            DetalhesRodada resultado = leitor.InterpretarDetalhesRodada(linha);

            //Assert
            Assert.NotNull(resultado);
        }

        [Theory]
        [InlineData("01	Corinthians		SP		81	38	24	9	5	71	")]
        public void Dado_UmaLinhaComNoveInformacoes_Quando_RealizarLeituraDaLinhaEsperandoDezInformacoes_Entao_UmaExcecaoDeLinhaComDadosIncompletosDeveSerLancada(string linha)
        {
            //Arrange            
            var leitor = new Infra.Leitores.LeitorTxtDadosCampeonato();

            //Assert
            Assert.Throws<DadosIncompletosException>(() =>
            {
                //Act
                DetalhesRodada resultado = leitor.InterpretarDetalhesRodada(linha);
            });
        }
    }
}
