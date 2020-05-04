using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEye.Crosscutting.ViewModel
{
    public class DadosComplementaresViewModel
    {
        public KeyValuePair<string, int> MelhorMediaDeGolsPro { get; set; }
        public KeyValuePair<string, int> MelhorMediaDeGolsContra { get; set; }
        public KeyValuePair<string, int> MaiorNumeroVitorias { get; set; }
        public KeyValuePair<string, int> MenorNumeroVitorias { get; set; }
        public KeyValuePair<string, int> MelhorMediaVitoriasPorCampeonato { get; set; }
        public KeyValuePair<string, int> MenorMediaVitoriasPorCampeonato { get; set; }
    }
}
