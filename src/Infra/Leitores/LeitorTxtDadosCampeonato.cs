using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TeamEye.Core.Crosscutting.Attributes;
using TeamEye.Core.Crosscutting.Utils;
using TeamEye.Core.Entities;
using TeamEye.Infra.Leitores.Exceptions;

namespace TeamEye.Infra.Leitores
{
    public class LeitorTxtDadosCampeonato : LeitorDadosCampeonatoAbstract
    {
        public override Rodada InterpretarDadosCampeonato(string dado)
        {
            throw new NotImplementedException();
        }
        public DetalhesRodada InterpretarDetalhesRodada(string linha)
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
            var relation = ReflectionHelper.RetornaCorrespondenciaCampoPosicao();

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
    }

    internal static class ReflectionHelper
    {
        private static List<Type> _tiposAvaliados = new List<Type>();
        private static List<Type> _tiposFaltandoAvaliar = new List<Type>();
        public static SortedDictionary<string, int> RetornaCorrespondenciaCampoPosicao()
        {
            SortedDictionary<string, int> relacaoCampoPosicao = new SortedDictionary<string, int>();

            foreach (var memberInfo in InspecionaMemberInfo(typeof(Rodada)))
            {
                foreach (TxtDataSourceAttribute attribute in memberInfo.GetCustomAttributes(typeof(TxtDataSourceAttribute), true))
                {
                    relacaoCampoPosicao.Add(memberInfo.Name, attribute.PositionOrder);
                }
            }
            _tiposAvaliados = new List<Type>();
            _tiposFaltandoAvaliar = new List<Type>();
            return relacaoCampoPosicao;
        }
        private static IEnumerable<MemberInfo> InspecionaMemberInfo(Type baseClass)
        {
            List<MemberInfo> infos = null;
            if (infos == null)
                infos = new List<MemberInfo>();

            var propertiesInfo = baseClass.GetProperties();
            do {
                if (_tiposFaltandoAvaliar.Count > 0)
                    propertiesInfo = _tiposFaltandoAvaliar.LastOrDefault().GetProperties();
                ColetaInformacoesPropriedades(propertiesInfo, infos);
            } while (_tiposFaltandoAvaliar.Count != 0);
            return infos;

        }
        private static IEnumerable<MemberInfo> ColetaInformacoesPropriedades(PropertyInfo[] propertiesInfo, List<MemberInfo> infos)
        {
            foreach (var propertyInfo in propertiesInfo)
            {
                if (propertyInfo.MemberType == System.Reflection.MemberTypes.Property && propertyInfo.CustomAttributes.Count() > 0)
                    infos.Add(propertyInfo);
                else if (propertyInfo.MemberType == System.Reflection.MemberTypes.Property 
                        && propertyInfo.PropertyType.Namespace == "TeamEye.Core.Entities" 
                        && propertyInfo.PropertyType != propertyInfo.DeclaringType
                        && !_tiposAvaliados.Contains(propertyInfo.PropertyType))
                    _tiposFaltandoAvaliar.Add(propertyInfo.PropertyType);
            }
            _tiposAvaliados.Add(propertiesInfo.FirstOrDefault().DeclaringType);
            if (_tiposFaltandoAvaliar.Contains(propertiesInfo.FirstOrDefault().DeclaringType))
                _tiposFaltandoAvaliar.Remove(propertiesInfo.FirstOrDefault().DeclaringType);
            return null;
        }
    }
}
