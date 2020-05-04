using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEye.Crosscutting.ViewModel
{
    public class DadosComplementaresViewModel
    {
        public KeyValuePair<string, int> MelhorMediaDeGolsPro { get; set; } = new KeyValuePair<string, int>();
        public KeyValuePair<string, int> MelhorMediaDeGolsContra { get; set; } = new KeyValuePair<string, int>();
        public KeyValuePair<string, int> MaiorNumeroVitorias { get; set; } = new KeyValuePair<string, int>();
        public KeyValuePair<string, int> MenorNumeroVitorias { get; set; } = new KeyValuePair<string, int>();
        public List<KeyValuePair<string, int>> MelhorMediaVitoriasPorCampeonato { get; set; } = new List<KeyValuePair<string, int>>();
        public List<KeyValuePair<string, int>> MenorMediaVitoriasPorCampeonato { get; set; } = new List<KeyValuePair<string, int>>();
    }
}
