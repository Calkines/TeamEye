using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;

namespace TeamEye.Infra.Leitores
{
    public class LeitorTxtDadosCampeonato : LeitorDadosCampeonatoAbstract
    {
        public override DetalhesRodada InterpretarDetalhesRodada(string linha)
        {
            var teste = DecompoemLinhasTextoEmPedacos(linha);
            throw new NotImplementedException();
        }

        private IEnumerable<string> DecompoemLinhasTextoEmPedacos(string line)
        {
            foreach (var chunk in line.Split('\t'))
            {
                if(!string.IsNullOrWhiteSpace(chunk))
                    yield return chunk;
            }
        }

        private DetalhesRodada ConvertePedacosTextoEmDetalhesRodada(IEnumerable<string> pedacosTexto)
        {
            Dictionary<string, int> relacaoCampoPosicao = new Dictionary<string, int>();
            
        }
    }
}
