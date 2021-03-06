﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TeamEye.Core.Attributes;
using TeamEye.Core.Crosscutting;
using TeamEye.Core.Entities;
using TeamEye.Crosscutting.Utils;
using TeamEye.Crosscutting.ViewModel;
using TeamEye.Infra.Leitores.Exceptions;

namespace TeamEye.Infra.Leitores
{
    public class LeitorTxtDadosCampeonato : LeitorDadosCampeonatoAbstract
    {
        private readonly IMapper _mapper;
        public LeitorTxtDadosCampeonato(IMapper mapper)
        {
            _mapper = mapper;
        }        

        public override Campeonato InterpretarDadosCampeonato(Stream stream)
        {            
            var ano = ProcurarAnoCampeonato(stream);
            var campeonato = new Campeonato(ano);
            LerDetalhesCampeonato(stream, campeonato);
            return campeonato;
        }
        private int ProcurarAnoCampeonato(Stream stream)
        {
            int ano = default;
            var sr = new StreamReader(stream);
            {
                while (!sr.EndOfStream && ano == default)
                {
                    var text = sr.ReadLine();
                    var linhaDividida = text.Trim().Split('\t');
                    if (linhaDividida.Length == 1) { 
                        int.TryParse(linhaDividida.FirstOrDefault(), out ano);
                    }
                }
            }
            if (ano == default)
                throw new CabecalhoNaoEncontradoException("Não foi possível encontrar o ano do campeonato");
            stream.Seek(0, SeekOrigin.Begin);
            return ano;
        }
        public LineDatailViewModel InterpretarDetalhesCampeonato(string linha)
        {
            var linhaDecomposta = DecompoemLinhasTextoEmPedacos(linha);
            return ConvertePedacosTextoEmDetalhesCampeonatoViewModel(linhaDecomposta);
        }
        private IEnumerable<string> DecompoemLinhasTextoEmPedacos(string linha)
        {
            foreach (var pedaco in linha.Split('\t'))
            {
                if (!string.IsNullOrWhiteSpace(pedaco))
                    yield return pedaco;
            }
        }
        private LineDatailViewModel ConvertePedacosTextoEmDetalhesCampeonatoViewModel(IEnumerable<string> pedacosTexto)
        {
            var relation = ReflectionHelper.RetornaCorrespondenciaCampoPosicao();

            if (relation.Count != pedacosTexto.Count())
                throw new DadosIncompletosException($"Era esperado {relation.Count} dado(s) para esta fonte, mas ela contém {pedacosTexto.Count()}");

            relation.TryGetValue(nameof(Time.Nome), out int posNomeTime);
            string nomeTime = pedacosTexto.ElementAtOneBased(posNomeTime);

            relation.TryGetValue(nameof(Estado.Sigla), out int posSiglaEstado);
            string siglaEstado = pedacosTexto.ElementAtOneBased(posSiglaEstado);

            relation.TryGetValue(nameof(DetalheCampeonato.Posicao), out int posPosicao);
            int.TryParse(pedacosTexto.ElementAtOneBased(posPosicao), out int posicao);

            relation.TryGetValue(nameof(DetalheCampeonato.Pontos), out int posPontos);
            int.TryParse(pedacosTexto.ElementAtOneBased(posPontos), out int pontos);

            relation.TryGetValue(nameof(DetalheCampeonato.Jogos), out int posJogos);
            int.TryParse(pedacosTexto.ElementAtOneBased(posJogos), out int jogos);

            relation.TryGetValue(nameof(DetalheCampeonato.Vitorias), out int posVitorias);
            int.TryParse(pedacosTexto.ElementAtOneBased(posVitorias), out int vitorias);

            relation.TryGetValue(nameof(DetalheCampeonato.Empates), out int posEmpates);
            int.TryParse(pedacosTexto.ElementAtOneBased(posEmpates), out int empates);

            relation.TryGetValue(nameof(DetalheCampeonato.Derrotas), out int posDerrotas);
            int.TryParse(pedacosTexto.ElementAtOneBased(posDerrotas), out int derrotas);

            relation.TryGetValue(nameof(DetalheCampeonato.GolsPro), out int posGolsPro);
            int.TryParse(pedacosTexto.ElementAtOneBased(posGolsPro), out int golsPro);

            relation.TryGetValue(nameof(DetalheCampeonato.GolsContra), out int posGolsContra);
            int.TryParse(pedacosTexto.ElementAtOneBased(posGolsContra), out int golsContra);

            return new LineDatailViewModel()
            {
                Derrotas = derrotas,
                Empates = empates,
                GolsContra = golsContra,
                GolsPro = golsPro,
                Posicao = posicao,
                Jogos = jogos,
                Pontos = pontos,
                Vitorias = vitorias,
                NomeTime = nomeTime,
                SiglaEstado = siglaEstado                
            };
        }
        private void LerDetalhesCampeonato(Stream stream, Campeonato campeonato)
        {
            stream.Seek(0, SeekOrigin.Begin);
            bool deveLerDetalhesCampeonato = false;
            var sr = new StreamReader(stream);
            while (!sr.EndOfStream)
            {
                var linha = sr.ReadLine();
                if (string.IsNullOrEmpty(linha) && deveLerDetalhesCampeonato || linha.Where(c => !char.IsControl(c)).Count() == 0)
                    continue;
                else if ((linha.Contains("----") && !deveLerDetalhesCampeonato))
                    deveLerDetalhesCampeonato = true;
                else if (deveLerDetalhesCampeonato)
                {
                    var viewmodel = InterpretarDetalhesCampeonato(linha);
                    var mapped = _mapper.Map<DetalheCampeonato>(viewmodel);
                    mapped.SetCampeonato(campeonato);
                    campeonato.RegistrarDetalhesCampeonato(mapped);
                }
            }
            stream.Seek(0, SeekOrigin.Begin);
        }
    }

    internal static class ReflectionHelper
    {
        private static List<Type> _tiposAvaliados = new List<Type>();
        private static List<Type> _tiposFaltandoAvaliar = new List<Type>();
        public static SortedDictionary<string, int> RetornaCorrespondenciaCampoPosicao()
        {
            SortedDictionary<string, int> relacaoCampoPosicao = new SortedDictionary<string, int>();

            foreach (var memberInfo in InspecionaMemberInfo(typeof(Campeonato)))
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
            do
            {
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
                        && isCoreOrGenericCoreType(propertyInfo)
                        && propertyInfo.PropertyType != propertyInfo.DeclaringType
                        && !_tiposAvaliados.Contains(propertyInfo.PropertyType))
                    _tiposFaltandoAvaliar.Add(propertyInfo.PropertyType);
            }
            _tiposAvaliados.Add(propertiesInfo.FirstOrDefault().DeclaringType);
            if (_tiposFaltandoAvaliar.Contains(propertiesInfo.FirstOrDefault().DeclaringType))
                _tiposFaltandoAvaliar.Remove(propertiesInfo.FirstOrDefault().DeclaringType);
            return null;
        }
        private static bool isCoreOrGenericCoreType(PropertyInfo propertyInfo)
        {
            if(propertyInfo.PropertyType.Namespace == "TeamEye.Core.Entities"
                || (propertyInfo.PropertyType.Namespace == "System.Collections.Generic" && propertyInfo.PropertyType.GetGenericArguments().FirstOrDefault()?.Namespace == "TeamEye.Core.Entities"))
            {
                return true;
            }
            return false;
        }
    }
}
