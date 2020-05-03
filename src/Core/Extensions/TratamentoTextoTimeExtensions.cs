using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TeamEye.Core.Extensions
{
    public static class TratamentoTextoTimeExtensions
    {
        private static Dictionary<string, string> _relacaoSiglaAdjetivo = new Dictionary<string, string>()
            {
                // Sul
                {"RS","Gaúcho" },
                {"SC","Catarinense" },
                {"PR","Paranaense" },

                // Sudeste
                {"SP","Paulista" },
                {"RJ","Fluminense" },
                {"MG","Mineiro" },
                {"ES","Capixaba" },

                // Centro-Oeste
                {"MS","Mato-Grossense-do-Sul" },
                {"MT","Mato-Grossense" },
                {"GO","Goiano" },

                // Nordeste
                {"BA","Baiano" },
                {"SE","Sergipano" },
                {"AL","Alagoano" },
                {"PE","Pernanbucano" },
                {"PB","Paraibano" },
                {"RN","Potiguar" },
                {"CE","Cearense" },
                {"PI","Piauiense" },
                {"MA","Maranhense" },

                // Norte
                {"RO","Rondoniense" },
                {"AC","Acreano" },
                {"AM","Amazonense" },
                {"RR","Roraimense" },
                {"PA","Paraense" },
                {"AP","Amapaense" },
                {"TO","Tocantinense" }
            };
        private static Dictionary<string, string> _relacaoGrafiaCorrecao = new Dictionary<string, string>()
        {
            {"Coritita","Coritiba" },
            {"Joinvile","Joinville" },
            {"CSA","Centro Sportivo Alagoano" }
        };
        public static string NormalizarString(this string input)
        {
            return new string(input.Normalize(NormalizationForm.FormD)
                                              .ToCharArray()
                                              .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                                              .ToArray()).ToUpper();
        }
        public static string TrocaSiglaEstadoPorAdjetivoPatrio(this string input)
        {
            foreach (var sigla in _relacaoSiglaAdjetivo.Keys)
            {
                if (input.ToUpper().Contains(' '+sigla+' ') || input.ToUpper().Substring(input.Length - 3, 3).Equals(' '+sigla))
                    return input.Replace(sigla, _relacaoSiglaAdjetivo[sigla], StringComparison.OrdinalIgnoreCase);
            }
            return input;
        }
        public static string CorrigeGrafia(this string input)
        {
            foreach (var sigla in _relacaoGrafiaCorrecao.Keys)
            {
                if (input.ToUpper().Contains(sigla + ' ') || 
                    input.ToUpper().Contains(' ' + sigla + ' ') || 
                    (input.Length >=3 && input.ToUpper().Substring(input.Length - 3, 3).Equals(' ' + sigla)) ||
                    (input.Length <= 3 && input.ToUpper().Contains(sigla))
                    )
                    return input.Replace(sigla, _relacaoGrafiaCorrecao[sigla], StringComparison.OrdinalIgnoreCase);
            }
            return input;
        }
    }
}
