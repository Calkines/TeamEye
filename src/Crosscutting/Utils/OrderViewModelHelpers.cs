using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamEye.Crosscutting.ViewModel;

namespace TeamEye.Crosscutting.Utils
{
    public static class OrderViewModelHelpers
    {
        public static CampeonatoViewModel OrdernarPorPosicao(this CampeonatoViewModel campeonato)
        {
            campeonato.DetalhesCampeonato = campeonato.DetalhesCampeonato.OrderBy(x => x.Posicao).ToList();
            return campeonato;
        }
    }
}
