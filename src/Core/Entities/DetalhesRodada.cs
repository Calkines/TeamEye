using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEye.Core.Entities
{
    class DetalhesRodada
    {        
        public int Pontos { get; private set; }
        public int Jogos { get; private set; }
        public int Vitorias { get; private set; }
        public int Empates { get; private set; }
        public int Derrotas { get; private set; }
        public int GolsPro { get; private set; }
        public int GolsContra { get; private set; }

        public Rodada Rodada { get; private set; }
        public Time Time { get; private set; }

        public void RegistrarVitoria(int gp, int gc)
        {

        }
        public void RegistrarDerrota(int gp, int gc)
        {

        }

        public void RegistrarEmpate(int gp, int gc)
        {

        }

        //public void RegistrarDetalhe(ResultadoPartidaEnum resultado, int gp, int gc)
        //{
        //    switch (resultado)
        //    {
        //        case ResultadoPartidaEnum.Vitoria:
        //            Pontos Regras.PONTOS_POR_VITORIA
        //            break;
        //        case ResultadoPartidaEnum.Derrota:
        //            break;
        //        case ResultadoPartidaEnum.Empate:
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }
}
