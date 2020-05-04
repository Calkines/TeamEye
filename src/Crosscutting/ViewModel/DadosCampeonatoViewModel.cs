using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;

namespace TeamEye.Crosscutting.ViewModel
{
    public class DadosCampeonatoViewModel
    {
        public List<Campeonato> Campeonatos { get; set; }
    }
    public class CampeonatoViewModel
    {
        public int Ano { get; set; }
        public string Nome { get; set; }
        public IList<DetalheCampeonatoViewModel> DetalhesCampeonato { get; set; }
    }
}
