using System;
using System.Text;
using TeamEye.Core.Entities;
using TeamEye.Infra.Leitores;
using Xunit;

namespace TeamEye.Tests
{
    public class TeamEyeCore
    {
        [Theory]
        [InlineData("01	Corinthians		SP		81	38	24	9	5	71	31	")]
        public void Dado_UmaLinhaEmUmArquivoDeTexto_Quando_RealizarLeituraDaLinha_Entao_UmObjetoRepresentandoOsDetalhesDaRodadaDeveSerRetornado(string linha)
        {
            //Arrange
            var leitor = new LeitorTxtDadosCampeonato();

            //Act
            DetalhesRodada resultado = leitor.InterpretarDetalhesRodada(linha);

            //Assert
            Assert.NotNull(resultado);
        }
    }
}
