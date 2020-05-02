using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamEye.Core.Crosscutting.Attributes;
using TeamEye.Core.Crosscutting.Utils;
using TeamEye.Core.Entities;
using TeamEye.Infra.Leitores.Exceptions;

namespace TeamEye.Infra.Leitores
{
    public class LeitorTxtDadosCampeonato : LeitorDadosCampeonatoAbstract
    {
        public override DetalhesRodada InterpretarDetalhesRodada(string linha)
        {
            var linhaDecomposta = DecompoemLinhasTextoEmPedacos(linha);
            return ConvertePedacosTextoEmDetalhesRodada(linhaDecomposta);
        }

        private IEnumerable<string> DecompoemLinhasTextoEmPedacos(string linha)
        {
            foreach (var pedaco in linha.Split('\t'))
            {
                if (!string.IsNullOrWhiteSpace(pedaco))
                    yield return pedaco;
            }
        }

        private DetalhesRodada ConvertePedacosTextoEmDetalhesRodada(IEnumerable<string> pedacosTexto)
        {
            var relation = RetornaCorrespondenciaCampoPosicao();

            if (relation.Count != pedacosTexto.Count())
                throw new DadosIncompletosException($"Era esperado {relation.Count} dado(s) para esta fonte, mas ela contém {pedacosTexto.Count()}");

            relation.TryGetValue(nameof(DetalhesRodada.Pontos), out int posPontos);
            int.TryParse(pedacosTexto.ElementAtOneBased(posPontos), out int pontos);

            relation.TryGetValue(nameof(DetalhesRodada.Jogos), out int posJogos);
            int.TryParse(pedacosTexto.ElementAtOneBased(posJogos), out int jogos);

            relation.TryGetValue(nameof(DetalhesRodada.Vitorias), out int posVitorias);
            int.TryParse(pedacosTexto.ElementAtOneBased(posVitorias), out int vitorias);

            relation.TryGetValue(nameof(DetalhesRodada.Empates), out int posEmpates);
            int.TryParse(pedacosTexto.ElementAtOneBased(posEmpates), out int empates);

            relation.TryGetValue(nameof(DetalhesRodada.Derrotas), out int posDerrotas);
            int.TryParse(pedacosTexto.ElementAtOneBased(posDerrotas), out int derrotas);

            relation.TryGetValue(nameof(DetalhesRodada.GolsPro), out int posGolsPro);
            int.TryParse(pedacosTexto.ElementAtOneBased(posGolsPro), out int golsPro);

            relation.TryGetValue(nameof(DetalhesRodada.GolsContra), out int posGolsContra);
            int.TryParse(pedacosTexto.ElementAtOneBased(posGolsContra), out int golsContra);

            Rodada rodada = null;
            Time time = null;
            return new DetalhesRodada(pontos, jogos, vitorias, empates, derrotas, golsPro, golsContra, rodada, time);
        }

        private Dictionary<string, int> RetornaCorrespondenciaCampoPosicao()
        {
            Dictionary<string, int> relacaoCampoPosicao = new Dictionary<string, int>();

            var membersInfo = typeof(Rodada).GetMembers();
            foreach (var memberInfo in membersInfo)
            {
                if (memberInfo.MemberType == System.Reflection.MemberTypes.Property && memberInfo.CustomAttributes.Count() > 0)
                {
                    foreach (TxtDataSourceAttribute attribute in memberInfo.GetCustomAttributes(typeof(TxtDataSourceAttribute), true))
                    {
                        relacaoCampoPosicao.Add(memberInfo.Name, attribute.PositionOrder);
                    }
                }                
            }
            return relacaoCampoPosicao;
        }
    }
}
